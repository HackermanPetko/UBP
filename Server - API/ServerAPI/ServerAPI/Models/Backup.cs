using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ServerAPI.Models
{
    public class Backup
    {
        [Key]
        public int Id { get; set; }
        public int IdDaemon { get; set; }
        public int IdTask { get; set; }
        public bool State { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime Date { get; set; }
        public string LogLocation { get; set; }

    }
}