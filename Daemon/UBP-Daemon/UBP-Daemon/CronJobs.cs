﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronNET;
using UBP_Daemon.BackupTypes;

namespace UBP_Daemon
{

    public class CronJobs
    {
        public static BackupTask task;

        public static void CheckConfigJob()
        {
            Configs.GetConfig(Service1.IdConfig).SaveConfigLocal();
        }

        public static void BackupJob()
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
}
