using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BackupTask
    {
        public int Id { get; set; }

        public int IdConfig { get; set; }

        public int BackupType { get; set; }

        public int Format { get; set; }

        public int RepeatInterval { get; set; }

        public List<Source> Sources { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}
