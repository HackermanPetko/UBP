﻿using ConsoleApp1.BackupTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(NetworkInterface
            //    .GetAllNetworkInterfaces()
            //    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            //    .Select(nic => nic.GetPhysicalAddress().ToString())
            //    .FirstOrDefault());


            //Console.ReadLine();
            Config config2 = Config.GetConfig(4);


            Console.WriteLine(config2.WriteAll());

            config2.SaveConfigLocal();

            Config config = Config.LoadConfigLocal();

            Console.WriteLine(config.WriteAll());





            string date = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");

            foreach (BackupTask task in config.Tasks)
            {
                foreach (Source source in task.Sources)
                {
                    foreach (Destination destination in task.Destinations)
                    {
                        if (destination.DestinationType == "LOCAL")
                            FullBackup.ToLocal(source.SourcePath, destination.DestinationAddress,date);
                        else if (destination.DestinationType == "FTP")
                        {
                            FullBackup.ToFTP(source.SourcePath, destination.DestinationAddress, destination.Port,
                                destination.DestinationUser, destination.DestinationPassword, date);
                        }
                        //else if (destination.DestinationType == "SFTP")
                        //{
                        //    FullBackup.ToSFTP(source.SourcePath, destination.DestinationAddress, Convert.ToInt32(destination.Port),
                        //        destination.DestinationUser, destination.DestinationPassword, date);
                        //}
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
