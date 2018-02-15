using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Daemon
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

        public Config()
        {

        }

        private async void LoadConfig(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63699/");

            HttpResponseMessage message = await client.GetAsync($"api/configs/{id}");

            if (message.IsSuccessStatusCode)
            {
                Config config = await message.Content.ReadAsAsync<Config>();
            }
            
        }
    }
}
