using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BackupTypes
{
    public class LocalBackup
    {
        public void FullBackup(string source, string destination,string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo(destination);

            this.CopyAll(dirSource, dirDest.CreateSubdirectory(date).CreateSubdirectory(dirSource.Name));
        }

        public void DifferentialBackup(string source, string destination)
        {

        }

        public void IncrementalBackup(string source, string destination)
        {

        }


        //kopírování všech souborů 
        private void CopyAll(DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
            }

            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                DirectoryInfo newdir = destination.CreateSubdirectory(dir.Name);
                this.CopyAll(dir, newdir);
            }
        }
    }
}
