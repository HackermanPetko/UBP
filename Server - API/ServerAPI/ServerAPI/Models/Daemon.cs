using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Daemon
    {
        [Key]
        public int Id { get; set; }

        public bool IsNew { get; set; }

        public string DaemonName { get; set; }

        public string DaemonMAC { get; set; }

        public DateTime LastConnected { get; set; }

        public string Comment { get; set; }

        [ForeignKey("Id")]
        public Config Configs { get; set; }
    }
}