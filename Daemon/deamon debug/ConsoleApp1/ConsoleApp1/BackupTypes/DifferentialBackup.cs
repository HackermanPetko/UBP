using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1.BackupTypes
{
    public class DifferentialBackup
    {
        // Local

        public static void ToLocal(string source, string destination, string date, int maxbackups)
        {
            //1|Differential|Source|Destination
            string[] backups = Log.GetBackups(destination).Where(x => x.Contains("|"+source+"|")).ToArray();
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
                FullBackup.ToFTP(source, destination,destaddres,port,user,password, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.MoveRemoteLog(sessionOptions, destaddres, backups);
                FullBackup.ToFTP(source, destination,destaddres, port,user,password, date);
            }
            else
            {
                string[] fullbackup = backups.First().Split('\\');
                string fullbackupdate = fullbackup[fullbackup.Count() - 2];
                StartRemoteCopyChanged(sessionOptions,dirSource, destaddres, DateTime.ParseExact(fullbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture),date);
                int id = backups.Count() + 1;
                Log.WriteRemoteBackup(sessionOptions,id, "Differential", source, destination, destaddres, port, date, dirSource.Name);
            }

        }

        private static void StartRemoteCopyChanged(SessionOptions sessionOptions, DirectoryInfo source, string destaddres, DateTime lastbackup, string date)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);


                if (source.GetFiles().Where(x => x.LastWriteTime > lastbackup).Count() != 0)
                    session.CreateDirectory($@"./{destaddres}/{date}/{source.Name}");

                RemoteCopyChanged(sessionOptions, source, $@"./{destaddres}/{date}/{source.Name}", lastbackup, date);
            }
        }


        private static void RemoteCopyChanged(SessionOptions sessionOptions, DirectoryInfo source, string destaddres, DateTime lastbackup,string date)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);



                foreach (FileInfo item in source.GetFiles().Where(x => x.LastWriteTime > lastbackup))
                {
                    Upload.UploadFile(sessionOptions, $"{destaddres}/{item.Name}", item.FullName);
                }
                foreach (DirectoryInfo item in source.GetDirectories().Where(x => x.LastWriteTime > lastbackup))
                {
                    RemoteCopyChanged(sessionOptions,item, $"{destaddres}/{item.Name}", lastbackup, date);
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
                FullBackup.ToSFTP(source, destination,destaddres, Convert.ToInt32(port), user, password, date);
            }
            else if (backups.Count() >= maxbackups && maxbackups != 0)
            {
                Log.MoveRemoteLog(sessionOptions, destaddres, backups);
                FullBackup.ToSFTP(source, destination,destaddres, Convert.ToInt32(port), user, password, date);
            }
            else
            {
                string[] fullbackup = backups.First().Split('\\');
                string fullbackupdate = fullbackup[fullbackup.Count() - 2];
                StartRemoteCopyChanged(sessionOptions, dirSource, destaddres, DateTime.ParseExact(fullbackupdate, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture),date);
                int id = backups.Count() + 1;
                Log.WriteRemoteBackup(sessionOptions, id, "Differential", source, destination, destaddres, port, date, dirSource.Name);
            }

        }

    }
}
