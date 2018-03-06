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

            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            NetworkCredential credentials = new NetworkCredential(user, password);

            CopyAllToFTP(dirSource, uri, reqFTP, credentials);
        }


        private static void CopyAllToFTP(DirectoryInfo dirSource, string uri, FtpWebRequest reqFTP, NetworkCredential credentials)
        {
            Stream ftpStream = null;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
            reqFTP.Credentials = credentials;
            reqFTP.UsePassive = false;
            reqFTP.UseBinary = true;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            ftpStream = response.GetResponseStream();
            ftpStream.Close();
            response.Close();


            foreach (FileInfo file in dirSource.GetFiles())
            {
                CopyFileToFTP(file, uri + "/" + file.Name, credentials);
            }

            foreach (DirectoryInfo dir in dirSource.GetDirectories())
            {
                CopyAllToFTP(dir, uri + "/" + dir.Name, reqFTP, credentials);
            }
        }

        private static void CopyFileToFTP(FileInfo file, string uri, NetworkCredential credentials)
        {
            FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            ftpWebRequest.ContentLength = file.Length;
            ftpWebRequest.Credentials = credentials;
            ftpWebRequest.UsePassive = false;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = file.OpenRead();

            Stream strm = ftpWebRequest.GetRequestStream();
            contentLen = fs.Read(buff, 0, buffLength);

            while (contentLen != 0)
            {
                strm.Write(buff, 0, contentLen);
                contentLen = fs.Read(buff, 0, buffLength);
            }

            strm.Close();
            fs.Close();
        }
    }
}
