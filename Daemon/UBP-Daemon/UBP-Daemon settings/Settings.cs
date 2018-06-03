using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace UBP_Daemon_settings
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
            }
            catch
            {

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
    }

    
}
