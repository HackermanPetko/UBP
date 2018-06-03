using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronNET;

namespace ConsoleApp1
{
    public class aaaa
    {
        public int IdConfig;

        public static CronDaemon cron = new CronDaemon();

        private void ResetJobs()
        {
            AddCronJobs();
        }

        private void AddCronJobs()
        {
            try
            {
                CronJobs.CheckConfigJob();
                cron.AddJob("15 * * * *", ResetJobs);

                foreach (BackupTask item in Configs.LoadConfigLocal().Tasks)
                {
                    if (item.MaxBackups == -1)
                    {
                        CronJobs.task = item;
                        string[] datumacas = item.RepeatInterval.Split(' ');
                        string[] datum = datumacas[0].Split('.');
                        string[] cas = datumacas[1].Split(':');

                        string cronstring = $"{cas[1]} {cas[0]} {datum[0]} {datum[1]} *";

                        Console.WriteLine(cronstring);
                        cron.AddJob(cronstring, CronJobs.BackupJob);
                        
                    }
                    else
                    {
                        CronJobs.task = item;
                        cron.AddJob(item.RepeatInterval, CronJobs.BackupJob);

                    }

                }
        }
            catch (Exception ex)
            {
                
            }
}

        public void Aaaaaa()
        {
            try
            {
                IdConfig = Configs.GetId();

                this.AddCronJobs();
                cron.Start();
            }
            catch (Exception ex)
            {

            }


        }

        public int ShowIdConfig()
        {
            return this.IdConfig;
        }

    }
}
