using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1.BackupTypes
{
    public class FullBackup
    {


        //Local

        public static void ToLocal(string source, string destination, string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo(destination);
            //1|Full|Source|Destination

            CopyAll(dirSource, dirDest.CreateSubdirectory(date).CreateSubdirectory(dirSource.Name));
            int id = Log.GetBackups(destination, source).Where(x => x.Contains("|" + source + "|")).ToArray().Count() + 1;
            Log.WriteBackup(id, "Full", source, destination, date, dirSource.Name);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
            }

            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                DirectoryInfo newdir = destination.CreateSubdirectory(dir.Name);
                CopyAll(dir, newdir);
            }
        }


        //FTP

        public static void ToFTP(string source, string destination, string port, string user, string password, string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);

            string directory = date + "/" + dirSource.Name;

            //NetworkCredential credentials = new NetworkCredential(user, password);
            //Upload.FTPDirectory(uri, credentials);

            SessionOptions sessionOptions = new SessionOptions()
            {
                Protocol = Protocol.Ftp,
                HostName = destination,
                PortNumber = Convert.ToInt32(port),
                UserName = user,
                Password = password
            };

            Upload.CreateDirectory(sessionOptions, directory);

            //FTPUploadAll(dirSource, uri, credentials);
            FTPUploadAll(sessionOptions, dirSource, directory);
        }


        private static void FTPUploadAll(SessionOptions sessionOptions, DirectoryInfo dirSource, string destination)//DirectoryInfo dirSource, string uri, NetworkCredential credentials)
        {
            foreach (FileInfo file in dirSource.GetFiles())
            {
                Upload.UploadFile(sessionOptions, destination, file.FullName);
                //Upload.FTPFile(file, uri + "\\" + file.Name, credentials);
            }

            foreach (DirectoryInfo dir in dirSource.GetDirectories())
            {
                Upload.CreateDirectory(sessionOptions, destination + "/" + dir.Name);
                FTPUploadAll(sessionOptions, dir, destination + "/" + dir.Name);
                //Upload.FTPDirectory(uri + "\\" + dir.Name, credentials);
                //FTPUploadAll(dir, uri + "\\" + dir.Name, credentials);
            }
            
        }

        // SSH

        public static void ToSFTP(string source, string destination, int port, string user, string password, string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);

            string directory = date + "/" + dirSource.Name;

            //NetworkCredential credentials = new NetworkCredential(user, password);
            //Upload.FTPDirectory(uri, credentials);

            SessionOptions sessionOptions = new SessionOptions()
            {
                Protocol = Protocol.Ftp,
                HostName = destination,
                PortNumber = Convert.ToInt32(port),
                UserName = user,
                Password = password
            };

            Upload.CreateDirectory(sessionOptions, directory);

            //FTPUploadAll(dirSource, uri, credentials);
            SFTPUploadAll(sessionOptions, dirSource, directory);
        }


        private static void SFTPUploadAll(SessionOptions sessionOptions, DirectoryInfo dirSource, string destination)
        {
            foreach (FileInfo file in dirSource.GetFiles())
            {
                Upload.UploadFile(sessionOptions, destination, file.FullName);
                //Upload.FTPFile(file, uri + "\\" + file.Name, credentials);
            }

            foreach (DirectoryInfo dir in dirSource.GetDirectories())
            {
                Upload.CreateDirectory(sessionOptions, destination + "/" + dir.Name);
                SFTPUploadAll(sessionOptions, dir, destination + "/" + dir.Name);
                //Upload.FTPDirectory(uri + "\\" + dir.Name, credentials);
                //FTPUploadAll(dir, uri + "\\" + dir.Name, credentials);
            }
        }
    }
}
