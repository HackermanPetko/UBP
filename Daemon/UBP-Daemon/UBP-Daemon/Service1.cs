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

            Start();

        }

        protected override void OnStop()
        {

        }

        private void AddCronJobs()
        {
            try
            {
                CronJobs.CheckConfigJob();
                cron.AddJob("15 * * * *", AddCronJobs);
                cron.AddJob("0 0 * * *", CronJobs.MailJob);

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

        private void Start()
        {

            try
            {
                cron = new CronDaemon();
                Settings.Get();

                IdConfig = Configs.GetId();

                this.AddCronJobs();
                cron.Start();
            }
            catch (Exception ex)
            {
                //Log.WriteToLog(@"C:\UBP", "error.txt", ex.StackTrace);
            }


        }
    }
}
