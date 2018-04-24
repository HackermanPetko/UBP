using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace ConsoleApp1.BackupTypes
{
    public class DatabaseBackup
    {
        public static void MysqlBackup(string source,string type, string date,string destination,string destaddress,  string port = null,string remoteuser = null,string remotepassword = null)
        {
            //$"server={server};user={user};pwd={password};database={database};"
            string constring = source;
            string file = "C:\\UBP\\tempbackup.sql";
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

            if (type == "Local")
            {
                string dest = destination + "\\" + date + "\\" + source.Split('=',';')[1] + "_" + source.Split('=', ';').Last() + ".sql";
                Directory.CreateDirectory(dest);
                File.Copy("C:\\UBP\\tempbackup.sql", dest);
            }
            else if (type == "FTP" || type == "SFTP")
            {
                string dest = destaddress + "/" + date + "/" + source.Split('=', ';')[1] + "_" + source.Split('=', ';').Last() + ".sql";
                SessionOptions sessionOptions = new SessionOptions()
                {
                    Protocol = type == "FTP" ? Protocol.Ftp : Protocol.Sftp,
                    HostName = destination,
                    PortNumber = Convert.ToInt32(port),
                    UserName = remoteuser,
                    Password = remotepassword
                };

                Upload.CreateDirectory(sessionOptions, date);
                Upload.UploadFile(sessionOptions, dest, "C:\\UBP\\tempbackup.sql");
            }
            File.Delete("C:\\UBP\\tempbackup.sql");
        }

    }
}
