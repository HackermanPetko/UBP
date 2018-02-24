using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Config
    {
        public int idConfig { get; set; }

        public int idDaemon { get; set; }

        public int BackupType { get; set; }

        public string DestinationType { get; set; }

        public string DestinationAddress { get; set; }

        public int FTPport { get; set; }

        public string DestinationPassword { get; set; }

        public string DestinationUser { get; set; }

        public int Format { get; set; }

        public bool Repeatable { get; set; }

        public int Interval { get; set; }

        public DateTime LastChecked { get; set; }

        public DateTime TimeStamp { get; set; }

        private Config()
        {

        }

        private static async Task<Config> LoadConfig(int id)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync($"http://localhost:63699/api/config/{id}");

            Config config = JsonConvert.DeserializeObject<Config>(json);

            //this.idConfig = config.idConfig;
            //this.idDaemon = config.idDaemon;
            //this.BackupType = config.BackupType;
            //this.DestinationType = config.DestinationType;
            //this.DestinationAddress = config.DestinationAddress;
            //this.FTPport = config.FTPport;
            //this.DestinationPassword = config.DestinationPassword;
            //this.DestinationUser = config.DestinationUser;
            //this.Format = config.Format;
            //this.Repeatable = config.Repeatable;
            //this.Interval = config.Interval;
            //this.LastChecked = config.LastChecked;

            return config;

        }

        public static Config GetConfig(int id)
        {
            var task = LoadConfig(id);
            task.Wait();
            Config config = task.Result;

            return config;
        }

        public void SaveConfigLocal()
        {
            string json = JsonConvert.SerializeObject(this);

            string subPath = @"C:\UBP"; // your code goes here

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);


            System.IO.File.WriteAllText(@"C:\UBP\Config.json", json);


        }

        public Config LoadConfigLocal()
        {
            Config config;
            string path = @"C:\UBP\Config.json";
            string content = File.ReadAllText(path);

            config = JsonConvert.DeserializeObject<Config>(content);


            return config;
        }
        //TEST KOMENTAR
    }
}
