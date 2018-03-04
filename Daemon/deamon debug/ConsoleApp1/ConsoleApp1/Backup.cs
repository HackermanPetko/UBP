using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Backup
    {
        public static void FullBackup(string source, string destination)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo(destination);

            CopyAll(dirSource, dirDest.CreateSubdirectory(DateTime.Now.ToString("yyyy_mm_dd-HH_mm_ss")).CreateSubdirectory(dirSource.Name));
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name),true);
            }

            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                DirectoryInfo newdir = destination.CreateSubdirectory(dir.Name);
                CopyAll(dir,newdir);
            }
        }

        public static void DifferentialBackup(string source, string destination)
        {

        }

        public static void IncrementalBackup(string source, string destination)
        {

        }
    }
}
