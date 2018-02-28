using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string UserToken { get; set; }
        public bool IsValid { get; set; }

    }

    
}