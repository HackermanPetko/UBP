using ConsoleApp1.BackupTypes;
using System;
using System.Collections.Generic;
using System.IO;
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
            Configs config2 = Configs.GetConfig(4);


            Console.WriteLine(config2.WriteAll());

            config2.SaveConfigLocal();

            Configs config = Configs.LoadConfigLocal();

            Console.WriteLine(config.WriteAll());


            Console.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UBP/backups.txt"));


            string date = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");

            foreach (BackupTask task in config.Tasks)
            {
                foreach (Sources source in task.Sources)
                {
                    foreach (Destinations destination in task.Destinations)
                    { //FullBackup
                        if (destination.DestinationType == "LOCAL" && task.BackupType == 1)
                            FullBackup.ToLocal(source.SourcePath, destination.Destination,date);
                        else if (destination.DestinationType == "FTP" && task.BackupType == 1)
                        {
                            FullBackup.ToFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                                destination.DestinationUser, destination.DestinationPassword, date);
                        }
                        //else if (destination.DestinationType == "SFTP" && task.BackupType == 1)
                        //{
                        //    FullBackup.ToSFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, Convert.ToInt32(destination.Port),
                        //        destination.DestinationUser, destination.DestinationPassword, date);
                        //}

                        //Differential
                        else if (destination.DestinationType == "LOCAL" && task.BackupType == 2)
                        {
                            DifferentialBackup.ToLocal(source.SourcePath, destination.Destination,date,task.MaxBackups);
                        }
                        else if (destination.DestinationType == "FTP" && task.BackupType == 2)
                        {
                            DifferentialBackup.ToFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                              destination.DestinationUser, destination.DestinationPassword, date, task.MaxBackups);
                        }
                        //else if (destination.DestinationType == "SFTP" && task.BackupType == 2)
                        //{
                        //    DifferentialBackup.ToSFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                        //        destination.DestinationUser, destination.DestinationPassword, date, task.MaxBackups);
                        //}

                        //Incremental
                        else if (destination.DestinationType == "LOCAL" && task.BackupType == 3)
                        {
                            IncrementalBackup.ToLocal(source.SourcePath, destination.Destination, date, task.MaxBackups);
                        }
                        else if (destination.DestinationType == "FTP" && task.BackupType == 3)
                        {
                            IncrementalBackup.ToFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                                destination.DestinationUser, destination.DestinationPassword, date, task.MaxBackups);
                        }
                        //else if (destination.DestinationType == "SFTP" && task.BackupType == 3)
                        //{
                        //    IncrementalBackup.ToSFTP(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                        //        destination.DestinationUser, destination.DestinationPassword, date, task.MaxBackups);
                        //}
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
