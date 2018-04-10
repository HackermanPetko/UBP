using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1.BackupTypes
{
    public class IncrementalBackup
    {
        public static void ToLocal(string source, string destination, string date, int maxbackups)
        {
            //1|Full|Source|Destination
            string[] backups = Log.GetBackups(destination).Where(x => x.Contains("|" + source + "|")).ToArray();
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo($@"{destination}\{date}\{dirSource.Name}");

            if (backups.Count() == 0)
            {
                FullBackup.ToLocal(source, destination, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.MoveLog(destination, backups);
                FullBackup.ToLocal(source, destination, date);
            }
            else
            {
                string[] lastbackup = backups.Last().Split('\\');
                string lastbackupdate = lastbackup[lastbackup.Count() - 2];
                CopyChanged(dirSource, dirDest, DateTime.ParseExact(lastbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture));
                int id = backups.Count() + 1;
                Log.WriteBackup(id, "Incremental", source, destination, date, dirSource.Name);
            }
        }

        private static void CopyChanged(DirectoryInfo source, DirectoryInfo destination, DateTime lastbackup)
        {
            foreach (FileInfo item in source.GetFiles().Where(x => x.LastWriteTime > lastbackup))
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

        public static void ToFTP(string source, string destination, string destaddres, string port, string user, string password, string date, int maxbackups)
        {

            SessionOptions sessionOptions = new SessionOptions()
            {
                Protocol = Protocol.Ftp,
                HostName = destination,
                PortNumber = Convert.ToInt32(port),
                UserName = user,
                Password = password
            };

            //1|Differential|Source|Destination
            string[] backups = Log.GetRemoteBackups(sessionOptions, destaddres).Where(x => x.Contains("|" + source + "|")).ToArray();
            DirectoryInfo dirSource = new DirectoryInfo(source);


            if (backups.Count() == 0)
            {
                FullBackup.ToFTP(source, destination, destaddres, port, user, password, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.MoveRemoteLog(sessionOptions, destaddres, backups);
                FullBackup.ToFTP(source, destination, destaddres, port, user, password, date);
            }
            else
            {
                string[] fullbackup = backups.Last().Split('\\');
                string fullbackupdate = fullbackup[fullbackup.Count() - 2];
                RemoteCopyChanged(sessionOptions, dirSource, destination, destaddres, DateTime.ParseExact(fullbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture));
                int id = backups.Count() + 1;
                Log.WriteRemoteBackup(sessionOptions, id, "Incremental", source, destination, destaddres, port, date, dirSource.Name);
            }

        }


        private static void RemoteCopyChanged(SessionOptions sessionOptions, DirectoryInfo source, string destination, string destaddres, DateTime lastbackup)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);



                foreach (FileInfo item in source.GetFiles().Where(x => x.LastWriteTime > lastbackup))
                {
                    session.CreateDirectory(destination);
                    Upload.UploadFile(sessionOptions, destaddres, item.FullName);
                }
                foreach (DirectoryInfo item in source.GetDirectories().Where(x => x.LastWriteTime > lastbackup))
                {
                    RemoteCopyChanged(sessionOptions, item, destination, destaddres, lastbackup);
                }
            }
        }


        // SSH

        public static void ToSFTP(string source, string destination, string destaddres, string port, string user, string password, string date, int maxbackups)
        {

            SessionOptions sessionOptions = new SessionOptions()
            {
                Protocol = Protocol.Sftp,
                HostName = destination,
                PortNumber = Convert.ToInt32(port),
                UserName = user,
                Password = password,
                GiveUpSecurityAndAcceptAnySshHostKey = true
                //SshHostKeyFingerprint = "ssh-rsa-82-0c-e8-9a-b6-30-30-ed-a0-0e-12-e8-eb-02-97-35-57-39-7c-72"

            };

            //1|Differential|Source|Destination
            string[] backups = Log.GetRemoteBackups(sessionOptions, destaddres).Where(x => x.Contains("|" + source + "|")).ToArray();
            DirectoryInfo dirSource = new DirectoryInfo(source);


            if (backups.Count() == 0)
            {
                FullBackup.ToSFTP(source, destination, destaddres, Convert.ToInt32(port), user, password, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.MoveRemoteLog(sessionOptions, destaddres, backups);
                FullBackup.ToSFTP(source, destination, destaddres, Convert.ToInt32(port), user, password, date);
            }
            else
            {
                string[] fullbackup = backups.Last().Split('\\');
                string fullbackupdate = fullbackup[fullbackup.Count() - 2];
                RemoteCopyChanged(sessionOptions, dirSource, destination, destaddres, DateTime.ParseExact(fullbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture));
                int id = backups.Count() + 1;
                Log.WriteRemoteBackup(sessionOptions, id, "Incremental", source, destination,destaddres,port, date, dirSource.Name);
            }

        }
    }
}
