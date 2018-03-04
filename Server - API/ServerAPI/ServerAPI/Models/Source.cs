using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }

        public int IdTask { get; set; }

        public string SourcePath { get; set; }


    }
}