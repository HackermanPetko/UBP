using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UBP_Daemon
{
    public class Backup
    {
        public int Id { get; set; }
        public int IdDaemon { get; set; }
        public int IdTask { get; set; }
        public bool State { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime Date { get; set; }
        public string LogLocation { get; set; }



        public static void Post(int daemon, int task, bool state, string errormsg, string log)
        {

            var dict = new Dictionary<string, dynamic>() {
                { "IdDaemon", daemon },
                { "IdTask", task },
                { "State", state },
                { "Date", DateTime.Now },
                { "ErrorMsg", errormsg },
                { "LogLocation", log }
            };


            HttpClient client = new HttpClient();

            
            // předání tokenu
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings.token);




            client.PostAsJsonAsync("http://localhost:63699/api/backups", dict);

        }


    }


}
