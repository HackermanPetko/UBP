using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BackupTypes
{
    public class FullBackup
    {


        //Local

        public static void ToLocal(string source, string destination, string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);
            DirectoryInfo dirDest = new DirectoryInfo(destination);

            CopyAll(dirSource, dirDest.CreateSubdirectory(date).CreateSubdirectory(dirSource.Name));
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

            string uri = "ftp://" + destination + ":" + port + "/" + date + "/" + dirSource.Name;

            NetworkCredential credentials = new NetworkCredential(user, password);

            FTPUploadAll(dirSource, uri, credentials);
        }


        private static void FTPUploadAll(DirectoryInfo dirSource, string uri, NetworkCredential credentials)
        {
            foreach (FileInfo file in dirSource.GetFiles())
            {
                Upload.FTPFile(file, uri + "/" + file.Name, credentials);
            }

            foreach (DirectoryInfo dir in dirSource.GetDirectories())
            {
                Upload.FTPDirectory(uri + "/" + dir.Name, credentials);
                FTPUploadAll(dir, uri + "/" + dir.Name, credentials);
            }
        }

        // SSH

        public static void ToSFTP(string source, string host, int port, string user, string password, string date)
        {
            DirectoryInfo dirSource = new DirectoryInfo(source);

            ConnectionInfo connection = new ConnectionInfo(host, port, user, new PasswordAuthenticationMethod(user, password));

            string destination = date + "/" + dirSource.Name;

            Upload.SFTPDirectory(connection, destination);

            SFTPUploadAll(dirSource, connection, destination);
        }


        private static void SFTPUploadAll(DirectoryInfo dirSource, ConnectionInfo connection,string destination)
        {
            foreach (FileInfo file in dirSource.GetFiles())
            {
                Upload.SFTPFile(connection,file.FullName, destination);
            }

            foreach (DirectoryInfo dir in dirSource.GetDirectories())
            {
                Upload.SFTPDirectory(connection, destination + "/" + dir.Name);
                SFTPUploadAll(dir, connection, destination + "/" + dir.Name);
            }
        }
    }
}
