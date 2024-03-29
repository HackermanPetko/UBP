﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UBP_Daemon
{
    public class AddNewDaemon
    {


        public static void Add()
        {
            var task = AddDaemon();
            task.Wait();
        }

        public static string GetMACAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();
        }

        private static async Task AddDaemon()
        {
            HttpClient client = new HttpClient();


            // předání tokenu
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings.token);

            var dict = new Dictionary<string, string>() {
                { "DaemonMAC", GetMACAddress() },
                { "IsNew", "true" },
                { "LastConnected", DateTime.Now.ToString() },
                { "DaemonName", Environment.MachineName }
            };

            var content = new FormUrlEncodedContent(dict);
            await client.PostAsync("http://localhost:63699/api/daemons", content);
        }

    }
}
