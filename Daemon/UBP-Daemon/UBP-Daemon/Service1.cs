using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CronNET;
using System.Threading;

namespace UBP_Daemon
{
    public partial class Service1 : ServiceBase
    {
        private int _idConfig;

        private Thread _thread;


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


        private void AddCronJobs()
        {
            try
            {
                CronManager.AddJob(new StartupCheckConfigJob(_idConfig));
                CronManager.AddJob(new CheckConfigJob(_idConfig));

                foreach (BackupTask item in Configs.LoadConfigLocal().Tasks)
                {
                    if (item.MaxBackups == -1)
                    {
                        CronManager.AddJob(new OneTimeJob(item));
                    }
                    else
                        CronManager.AddJob(new CronJob(item));
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
                _idConfig = Configs.GetId();

                if (_idConfig == 0)
                    AddNewDaemon.Add();

                //this.AddCronJobs();
                CronManager.Start();
            }
            catch (Exception ex)
            {
                Log.WriteToLog("C:\\UBP", "error.txt", ex.StackTrace);
            }


        }
    }
}
