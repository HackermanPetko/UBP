using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerAPI
{
    public class Config
    {
        public int idConfig { get; set; }

        public int idDaemona { get; set; }

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
    }
}