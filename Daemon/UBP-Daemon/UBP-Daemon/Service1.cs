using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CronNET;

namespace UBP_Daemon
{
    public partial class Service1 : ServiceBase
    {
        private static int _idConfig;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _idConfig = Configs.GetId();

            if (_idConfig == 0)
                AddNewDaemon.Add();

            this.AddCronJobs();
            CronManager.Start();
        }

        protected override void OnStop()
        {

        }


        private void AddCronJobs()
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
    }
}
