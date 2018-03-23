using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BackupTypes
{
    public class DifferentialBackup
    {
        // Local

        public static void ToLocal(string source, string destination, string date)
        {
            //1|Differential|Source|Destination
            string[] backups = GetLog(destination,source).Where(x => x.Contains(source)).ToArray();

            if (backups.Count() == 0)
            {
                FullBackup.ToLocal(source, destination, date);
                WriteToLog(destination, $"1|Full|{source}|{destination}");
            }
            else
            {
                
                DirectoryInfo dirSource = new DirectoryInfo(source);
                DirectoryInfo dirDest = new DirectoryInfo(destination);

                CopyChanged(dirSource, dirDest);
            }
        }

        private static void CopyChanged(DirectoryInfo source, DirectoryInfo destination)
        {

        }

        // FTP

        // SSH

        // Log

        private static string[] GetLog(string destination, string source)
        {

            Directory.CreateDirectory(destination);

            if (!File.Exists(destination + "/backups.txt"))
            {
                File.Create(destination + "/backups.txt").Close(); ;

            }

            return File.ReadAllLines(destination + "/backups.txt");
        }

        private static void WriteToLog(string destination, string text)
        {

            using (StreamWriter writer = new StreamWriter(destination + "/backups.txt",true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
