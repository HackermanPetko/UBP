﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ServerAPI.Models
{
    public class Backup
    {
        [Key]
        public int idBackup { get; set; }
        public int idDaemon { get; set; }
        public bool State { get; set; }
        public string ErrorMsg { get; set; }
        public int BackupType {get; set; }
        public DateTime Date { get; set; }
        public string LogLocation { get; set; }




    }
}