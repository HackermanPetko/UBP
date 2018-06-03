using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace UBP_Daemon
{
    public static class Settings
    {
        public static string user;
        public static string token;
        public static string password;
        public static string server;

        public static void Get()
        {
            try
            {
                //string encryptedsettings = File.ReadAllText(@"C:\UBP\settings.AAAAAA");
                //string settings = Encryption.Decrypt(encryptedsettings);

                string settings = File.ReadAllText(@"C:\UBP\settings.AAAAAA");
                SettingsClass set = JsonConvert.DeserializeObject<SettingsClass>(settings);
                Settings.user = set.user;
                token = set.token;
                password = set.password;
                server = set.server;
                if (token == null)
                    Login();
            }
            catch
            {
                Log.WriteToLog(@"C:\UBP", "login.txt", $"{user},{token},{password},{server}");
            }
        }

        public static void Upload()
        {
            //string encryptedsettings = Encryption.Encrypt(JsonConvert.SerializeObject(new SettingsClass() { user = user, password = password, token = token, server = server }));

            string encryptedsettings = JsonConvert.SerializeObject(new SettingsClass() { user = user, password = password, token = token, server = server });
            File.WriteAllText(@"C:\UBP\settings.AAAAAA", encryptedsettings);
        }

        private class SettingsClass
        {
            public string user;
            public string token;
            public string password;
            public string server;
        }

        private static async Task<string> beginLogin()
        {

            HttpClient client = new HttpClient();


            var dict = new Dictionary<string, string>() {
                { "Username", Settings.user },
                { "Password", Settings.password }
            };


            var response = await client.PostAsJsonAsync("http://localhost:63699/api/login", dict);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                return null;
        }


        private static void Login()
        {

            var token = beginLogin();
            token.Wait();

            Settings.token = token.Result.Trim('"');
            Upload();
        }


    }

    
}
