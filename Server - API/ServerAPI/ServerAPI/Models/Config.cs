using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Config
    {
        //private TestContext context;
        [Key]
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
    }
}