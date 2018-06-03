using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1
{
    public class Log
    {
        public static string[] GetBackups(string destination)
        {

            Directory.CreateDirectory(destination);

            if (!File.Exists(destination + "/backups.txt"))
            {

                CreateBackupsLog(destination);
            }

            return File.ReadAllLines(destination + "/backups.txt");
        }

        public static void WriteBackup(int id, string type, string source, string destination, string date, string directoryname)
        {
            using (StreamWriter writer = new StreamWriter(destination + "/backups.txt", true))
            {
                writer.WriteLine($@"{id}|{type}|{source}|{destination}\{date}\{directoryname}");
            }
        }

        public static void WriteToLog(string destination, string file, string text)
        {
            using (StreamWriter writer = new StreamWriter(destination + "/" + file, true))
            {
                File.SetAttributes(destination + "/" + file, FileAttributes.Normal);
                writer.WriteLine(text);
            }
            File.SetAttributes(destination + "/" + file, FileAttributes.Hidden);
        }

        public static void MoveLog(string destination, string[] lines)
        {
            if(File.Exists(destination + "/backups.txt.old"))
                File.SetAttributes(destination + "/backups.txt.old", FileAttributes.Normal);
            File.AppendAllLines(destination + "/backups.txt.old", lines);
            Log.CreateBackupsLog(destination);
            File.SetAttributes(destination + "/backups.txt.old", FileAttributes.Hidden);
        }

        public static void CreateBackupsLog(string destination)
        {
            if (File.Exists(destination + "/backups.txt"))
            {
                File.SetAttributes(destination + "/backups.txt", FileAttributes.Normal);
            }
            File.Create(destination + "/backups.txt").Close();
            File.SetAttributes(destination + "/backups.txt", FileAttributes.Hidden);
        }

        public static string[] GetRemoteBackups(SessionOptions sessionOptions, string destination)
        {
            List<string> backups = new List<string>();
            using (Session session = new Session())
            {
                session.Open(sessionOptions);
                TransferOptions options = new TransferOptions();
                options.TransferMode = TransferMode.Binary;
                options.OverwriteMode = OverwriteMode.Overwrite;
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UBP"));

                session.GetFiles("./" + destination + "/backups.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt"),false, options);
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt")))
                {
                    foreach(string item in File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt")))
                    {
                        backups.Add(item);
                    }

                    
                }
            }
            return backups.ToArray();
        }

        public static void WriteRemoteBackup(SessionOptions sessionOptions, int id, string type, string source, string destination,string destaddres, string port, string date, string directoryname)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);

                TransferOptions options = new TransferOptions();
                options.TransferMode = TransferMode.Binary;
                options.OverwriteMode = OverwriteMode.Overwrite;

                using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt"),true))
                {
                    writer.WriteLine($@"{id}|{type}|{source}|{destination}:{port}\{destaddres}\{date}\{directoryname}");
                }
                session.PutFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt"), "./" + destaddres + "/backups.txt",true, options);
                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt"));
            }
        }

        public static void MoveRemoteLog(SessionOptions sessionOptions,string destination, string[] lines)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);

                TransferOptions options = new TransferOptions();
                options.TransferMode = TransferMode.Binary;
                options.OverwriteMode = OverwriteMode.Overwrite;

                if (session.FileExists("./" + destination + @"/backups.txt.old"))
                    session.GetFiles("./" + destination + @"/backups.txt.old", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt.old"), false, options);

                File.AppendAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt.old"), lines);
                Log.CreateRemoteBackupsLog(sessionOptions,destination);
                session.PutFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt.old"), "./" + destination + @"/backups.txt.old",true, options);
            }
        }

        public static void CreateRemoteBackupsLog(SessionOptions sessionOptions, string destination)
        {
            using (Session session = new Session())
            {
                TransferOptions options = new TransferOptions();
                options.TransferMode = TransferMode.Binary;
                options.OverwriteMode = OverwriteMode.Overwrite;
                session.Open(sessionOptions);
                File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt")).Close();

                session.PutFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"UBP\backups.txt"), "./" + destination + "/backups.txt",true,options);

            }
        }
    }
}
