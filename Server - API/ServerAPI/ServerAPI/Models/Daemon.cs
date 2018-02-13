using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Daemon
    {
        [Key]
        public int idDaemon { get; set; }
        public bool IsNew { get; set; }
        public string DaemonName { get; set; }

    }
}