using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronNET;
using UBP_Daemon.BackupTypes;

namespace UBP_Daemon
{

    public class CheckConfigJob : BaseJob
    {
        public override CronExpression Cron => new CronExpression("15 * * * *");

        private int _ConfigId;

        public CheckConfigJob(int Config)
        {
            this._ConfigId = Config;
        }

        public override void Execute()
        {
            Configs.GetConfig(_ConfigId).SaveConfigLocal();
        }
    }

    public class StartupCheckConfigJob : BaseJob
    {
        public override CronExpression Cron => CronExpression.Startup;

        private int _ConfigId;

        public StartupCheckConfigJob(int Config)
        {
            this._ConfigId = Config;
        }

        public override void Execute()
        {
            Configs.GetConfig(_ConfigId).SaveConfigLocal();
            CronManager.RemoveJob(this.JobID);
        }
    }

    public class CronJob : BaseJob
    {
        public override CronExpression Cron => new CronExpression(this.task.RepeatInterval);


        private BackupTask task;

        public CronJob(BackupTask task)
        {
            this.task = task;
        }


        public override void Execute()
        {
            string date = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");


            foreach (Sources source in task.Sources)
            {
                foreach (Destinations destination in task.Destinations)
                { //FullBackup
                    if (task.BackupType == 1) //full
                        FullBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.Format);
                    else if (task.BackupType == 2) //incr
                        IncrementalBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.MaxBackups, task.Format);
                    else if (task.BackupType == 3) // diff
                        DifferentialBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.MaxBackups, task.Format);
                    else if (task.BackupType == 4) // mysql database
                        DatabaseBackup.MysqlBackup(source.SourcePath, destination.DestinationType, date, destination.Destination, destination.DestinationAddress, destination.Port, destination.DestinationUser, destination.DestinationPassword);
                }
            }

        }

    }

    public class OneTimeJob : BaseJob
    {
        public override CronExpression Cron => new CronExpression(cron);

        private BackupTask task;
        private string cron;

        public OneTimeJob(BackupTask task)
        {
            this.task = task;
            string[] datumacas = task.RepeatInterval.Split(' ');
            string[] datum = datumacas[0].Split('.');
            string[] cas = datumacas[1].Split(':');

            this.cron = $"{cas[1]} {cas[0]} {datum[0]} {datum[1]} *";
        }

        public override void Execute()
        {
            string date = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");

            foreach (Sources source in task.Sources)
            {
                foreach (Destinations destination in task.Destinations)
                { //FullBackup
                    if (task.BackupType == 1) //full
                        FullBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.Format);
                    else if (task.BackupType == 2) //incr
                        IncrementalBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.MaxBackups, task.Format);
                    else if (task.BackupType == 3) // diff
                        DifferentialBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                            destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType, task.MaxBackups, task.Format);
                    else if (task.BackupType == 4) // mysql database
                        DatabaseBackup.MysqlBackup(source.SourcePath, destination.DestinationType, date, destination.Destination, destination.DestinationAddress, destination.Port, destination.DestinationUser, destination.DestinationPassword);
                }
            }


            CronManager.RemoveJob(this.JobID);
        }
    }
}
