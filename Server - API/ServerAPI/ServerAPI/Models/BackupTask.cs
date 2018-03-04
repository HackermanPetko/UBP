using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    [Table("Task")]
    public class BackupTask
    {
        [Key]
        public int Id { get; set; }

        public int IdConfig { get; set; }

        public int BackupType { get; set; }

        public int Format { get; set; }

        public int RepeatInterval { get; set; }

        [ForeignKey("IdTask")]
        public ICollection<Source> Sources { get; set; }

        [ForeignKey("IdTask")]
        public ICollection<Destination> Destinations { get; set; }
    }
}