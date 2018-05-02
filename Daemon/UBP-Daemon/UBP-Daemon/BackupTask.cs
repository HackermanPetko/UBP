using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBP_Daemon
{
    public class BackupTask
    {
        public int Id { get; set; }

        public int IdConfig { get; set; }

        public int BackupType { get; set; }

        public int Format { get; set; }

        public string RepeatInterval { get; set; }

        public int MaxBackups { get; set; }

        public List<Sources> Sources { get; set; }

        public List<Destinations> Destinations { get; set; }
    }
}
