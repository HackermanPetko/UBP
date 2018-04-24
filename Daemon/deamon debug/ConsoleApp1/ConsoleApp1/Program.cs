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
                        if (task.BackupType == 1) //full
                            FullBackup.Start(source.SourcePath, destination.Destination, destination.DestinationAddress, destination.Port,
                              destination.DestinationUser, destination.DestinationPassword, date, destination.DestinationType,task.Format);
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

            Console.ReadLine();
        }
    }
}
