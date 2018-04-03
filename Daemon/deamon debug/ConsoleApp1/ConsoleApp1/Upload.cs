//using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1
{
    public class Upload
    {

        //FTP

        //                        //Upload file
        //public static void FTPFile(FileInfo file, string uri, NetworkCredential credentials)
        //{
        //    FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
        //    ftpWebRequest.ContentLength = file.Length;
        //    ftpWebRequest.Credentials = credentials;
        //    ftpWebRequest.UsePassive = false;
        //    ftpWebRequest.UseBinary = true;
        //    ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

        //    int buffLength = 2048;
        //    byte[] buff = new byte[buffLength];
        //    int contentLen;

        //    FileStream fs = file.OpenRead();

        //    Stream strm = ftpWebRequest.GetRequestStream();
        //    contentLen = fs.Read(buff, 0, buffLength);

        //    while (contentLen != 0)
        //    {
        //        strm.Write(buff, 0, contentLen);
        //        contentLen = fs.Read(buff, 0, buffLength);
        //    }

        //    strm.Close();
        //    fs.Close();
        //}

        //                            //Create directory
        //public static void FTPDirectory(string uri, NetworkCredential credentials)
        //{
        //    Stream ftpStream = null;
        //    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
        //    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
        //    reqFTP.Credentials = credentials;
        //    reqFTP.UsePassive = false;
        //    reqFTP.UseBinary = true;
        //    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //    ftpStream = response.GetResponseStream();
        //    ftpStream.Close();
        //    response.Close();
        //}

        //// SSH
        //                            //Upload file
        //public static void SFTPFile(ConnectionInfo connection, string sourcefile, string destinationpath)
        //{
        //    using (SftpClient client = new SftpClient(connection))
        //    {
        //        client.Connect();
        //        client.ChangeDirectory(destinationpath);
        //        using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
        //        {
        //            client.BufferSize = 4 * 1024;
        //            client.UploadFile(fs, Path.GetFileName(sourcefile));
        //        }
        //    }
        //}

        ////Create directory
        //public static void SFTPDirectory(ConnectionInfo connection, string destinationpath)
        //{
        //    using (SftpClient client = new SftpClient(connection))
        //    {
        //        client.Connect();
        //        if(!client.Exists(destinationpath))
        //            client.CreateDirectory(destinationpath);
        //    }
        //}


        public static void UploadFile(SessionOptions options, string destination, string source)
        {
            //SessionOptions options = new SessionOptions()
            //{
            //    Protocol = Protocol.Ftp,
            //    HostName = destination,
            //    PortNumber = port,
            //    UserName = username,
            //    Password = password
            //};

            using (Session session = new Session())
            {
                session.Open(options);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                //transferResult = session.GetFiles(destination, @"d:\download\", false, transferOptions);
                session.PutFiles(source, destination, false, transferOptions);
            }
        }

        public static void CreateDirectory(SessionOptions options, string destination)
        {
            using (Session session = new Session())
            {
                session.Open(options);

                session.CreateDirectory(destination);
            }
        }
    }
}
