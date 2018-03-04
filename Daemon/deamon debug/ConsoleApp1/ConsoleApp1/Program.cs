using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.GetConfig(4);


            Console.WriteLine(config.WriteAll());

            config.SaveConfigLocal();

            config.LoadConfigLocal();

            Console.WriteLine(config.WriteAll());

            Console.ReadLine();

            foreach (BackupTask task in config.Tasks)
            {
                foreach (Source source in task.Sources)
                {
                    foreach (Destination destination in task.Destinations)
                    {
                        Backup.FullBackup(source.SourcePath, destination.DestinationAddress);
                    }
                }
            }
        }
    }
}
