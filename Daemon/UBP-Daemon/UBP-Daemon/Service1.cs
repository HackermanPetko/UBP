using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CronNET;

namespace UBP_Daemon
{
    public partial class Service1 : ServiceBase
    {
        public static int IdConfig;

        private CronDaemon cron;


        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Aaaaaa();

        }

        protected override void OnStop()
        {

        }

        private void ResetJobs()
        {
            this.cron = new CronDaemon();
            AddCronJobs();
        }

        private void AddCronJobs()
        {
            try
            {
                CronJobs.CheckConfigJob();
                cron.AddJob("15 * * * *",ResetJobs);

                foreach (BackupTask item in Configs.LoadConfigLocal().Tasks)
                {
                    if (item.MaxBackups == -1)
                    {
                        CronJobs.task = item;
                        string[] datumacas = item.RepeatInterval.Split(' ');
                        string[] datum = datumacas[0].Split('.');
                        string[] cas = datumacas[1].Split(':');

                        string cronstring = $"{cas[1]} {cas[0]} {datum[0]} {datum[1]} *";

                        cron.AddJob(cronstring, CronJobs.BackupJob);
                        Log.WriteToLog("C:\\UBP", "Crons.txt",cronstring);
                    }
                    else
                    {
                        CronJobs.task = item;
                        cron.AddJob(item.RepeatInterval, CronJobs.BackupJob);
                        Log.WriteToLog("C:\\UBP", "Crons.txt",item.RepeatInterval);
                    }
                        
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("C:\\UBP", "errorCron.txt", ex.StackTrace);
            }
        }

        private void Aaaaaa()
        {
            try
            {
                IdConfig = Configs.GetId();

                if (IdConfig == 0)
                    AddNewDaemon.Add();

                this.AddCronJobs();
                cron.Start();
            }
            catch (Exception ex)
            {
                Log.WriteToLog("C:\\UBP", "error.txt", ex.StackTrace);
            }


        }
    }
}
