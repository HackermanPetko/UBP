using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BackupTypes
{
    public class IncrementalBackup
    {
        public static void ToLocal(string source, string destination, string date, int maxbackups)
        {
            //1|Full|Source|Destination
            string[] backups = Log.GetBackups(destination, source).Where(x => x.Contains("|" + source + "|")).ToArray();
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
    }
}
