﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UBP_Daemon
{
    public class Configs
    {
        public int idDaemon { get; set; }

        public string Comment { get; set; }

        public DateTime LastChecked { get; set; }

        public DateTime TimeStamp { get; set; }

        public List<BackupTask> Tasks { get; set; }

        private Configs()
        {

        }

        private static async Task<Configs> LoadConfig(int id)
        {
            HttpClient client = new HttpClient();


            // předání tokenu
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings1.Default.token);


            string json = await client.GetStringAsync($"http://localhost:63699/api/config/{id}");

            Configs config = JsonConvert.DeserializeObject<Configs>(json);


            return config;

        }

        public static Configs GetConfig(int id)
        {
            var task = LoadConfig(id);
            task.Wait();
            Configs config = task.Result;

            return config;
        }

        public void SaveConfigLocal()
        {
            string json = JsonConvert.SerializeObject(this);

            string subPath = @"C:\UBP"; 

            bool exists = Directory.Exists(subPath);

            if (!exists)
                Directory.CreateDirectory(subPath);


            File.WriteAllText(@"C:\UBP\Config.json", json);


        }

        public static Configs LoadConfigLocal()
        {
            Configs config;
            string path = @"C:\UBP\Config.json";
            string content = File.ReadAllText(path);

            config = JsonConvert.DeserializeObject<Configs>(content);


            return config;
        }
        //TEST KOMENTAR

        public string WriteAll()
        {
            return JsonConvert.SerializeObject(this).ToString();
        }


        private static async Task<int> GetConfigId()
        {
            HttpClient client = new HttpClient();


            // předání tokenu
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings1.Default.token);

            var dict = new Dictionary<string, string>() {
                {
                    "DaemonMAC", AddNewDaemon.GetMACAddress()
                } };

            var content = new FormUrlEncodedContent(dict);

            var response = await client.PostAsync("http://localhost:63699/api/daemons", content);

            string id = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(id);

        }

        public static int GetId()
        {
            var task = GetConfigId();
            task.Wait();
            int id = task.Result;

            return id;
        }
    }
}
