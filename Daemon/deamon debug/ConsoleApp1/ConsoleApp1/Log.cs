using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Log
    {
        public static string[] GetBackups(string destination, string source)
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
                File.SetAttributes(destination + "/backups.txt", FileAttributes.Normal);
                writer.WriteLine(text);
            }
            File.SetAttributes(destination + "/backups.txt", FileAttributes.Hidden);
        }

        public static void CreateBackupsLog(string destination)
        {
            File.Create(destination + "/backups.txt").Close();
            File.SetAttributes(destination + "/backups.txt", FileAttributes.Hidden);
        }

    }
}
