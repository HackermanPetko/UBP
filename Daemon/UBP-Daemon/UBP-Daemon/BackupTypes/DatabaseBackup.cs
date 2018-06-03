using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace UBP_Daemon.BackupTypes
{
    public class DatabaseBackup
    {
        public static void MysqlBackup(int taskid,string source, string type, string date, string destination, string destaddress, string port = null, string remoteuser = null, string remotepassword = null)
        {
            try
            {
                //$"server={server};user={user};pwd={password};database={database};"
                string constring = source;
                string file = Environment.CurrentDirectory + "\\tempbackup.sql";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }

                if (type == "LOCAL")
                {
                    string dest = destination + "\\" + date + "\\" + source.Split('=', ';')[1];
                    Directory.CreateDirectory(dest);
                    File.Copy(Environment.CurrentDirectory + "\\tempbackup.sql", dest + "\\" + source.Split('=').Last().TrimEnd(';') + ".sql");
                }
                else if (type == "FTP" || type == "SFTP")
                {
                    string dest = destaddress + "/" + date + "/" + source.Split('=', ';')[1];
                    SessionOptions sessionOptions = new SessionOptions()
                    {
                        Protocol = type == "FTP" ? Protocol.Ftp : Protocol.Sftp,
                        HostName = destination,
                        PortNumber = Convert.ToInt32(port),
                        UserName = remoteuser,
                        Password = remotepassword
                    };

                    Upload.CreateDirectory(sessionOptions, date);
                    Upload.UploadFile(sessionOptions, dest + "/" + source.Split('=').Last().TrimEnd(';') + ".sql", Environment.CurrentDirectory + "\\tempbackup.sql");
                }
                File.Delete(Environment.CurrentDirectory + "\\tempbackup.sql");

                Backup.Post(Service1.IdConfig, taskid, true, "succesful", "");
            }
            catch
            {
                Backup.Post(Service1.IdConfig, taskid, false, "error", "");
            }
        }

    }
}
