using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        public int IdTask { get; set; }

        public string DestinationType { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationUser { get; set; }

        public string DestinationPassword { get; set; }

        public string FTPport { get; set; }

    }
}