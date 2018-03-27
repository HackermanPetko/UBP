using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BackupTypes
{
    public class DifferentialBackup
    {
        // Local

        public static void ToLocal(string source, string destination, string date, int maxbackups)
        {
            //1|Differential|Source|Destination
            string[] backups = Log.GetBackups(destination,source).Where(x => x.Contains("|"+source+"|")).ToArray();
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo($@"{destination}\{date}\{dirSource.Name}");

            if (backups.Count() == 0)
            {
                FullBackup.ToLocal(source, destination, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.CreateBackupsLog(destination);
                FullBackup.ToLocal(source, destination, date);
            }
            else
            {
                string[] fullbackup = backups.First().Split('\\');
                string fullbackupdate = fullbackup[fullbackup.Count() - 2];
                CopyChanged(dirSource, dirDest, DateTime.ParseExact(fullbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture));
                int id = backups.Count() + 1;
                Log.WriteBackup(id, "Differential", source, destination, date, dirSource.Name);
            }
        }

        private static void CopyChanged(DirectoryInfo source, DirectoryInfo destination, DateTime lastbackup)
        {
            foreach (FileInfo item in source.GetFiles().Where(x=>x.LastWriteTime > lastbackup))
            {
                Directory.CreateDirectory(destination.FullName);
                item.CopyTo(Path.Combine(destination.FullName, item.Name), true);
            }
            foreach (DirectoryInfo item in source.GetDirectories().Where(x => x.LastWriteTime > lastbackup))
            {
                DirectoryInfo newdir = destination.CreateSubdirectory(item.Name);
                CopyChanged(item, newdir, lastbackup);
            }
        }

        // FTP

        //public static void ToFTP(string source, string destination, string port, string user, string password, string date, int maxbackups)
        //{
        //    DirectoryInfo dirSource = new DirectoryInfo(source);

        //    string uri = "ftp://" + destination + ":" + port + "\\" + date + "\\" + dirSource.Name;

        //    NetworkCredential credentials = new NetworkCredential(user, password);
        //    Upload.FTPDirectory(uri, credentials);

        //    FTPUploadAll(dirSource, uri, credentials);
        //}


        //private static void FTPUploadAll(DirectoryInfo dirSource, string uri, NetworkCredential credentials)
        //{
        //    foreach (FileInfo file in dirSource.GetFiles())
        //    {
        //        Upload.FTPFile(file, uri + "\\" + file.Name, credentials);
        //    }

        //    foreach (DirectoryInfo dir in dirSource.GetDirectories())
        //    {
        //        Upload.FTPDirectory(uri + "\\" + dir.Name, credentials);
        //        FTPUploadAll(dir, uri + "\\" + dir.Name, credentials);
        //    }
        //}

        // SSH

    }
}
