using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBP_Daemon
{
    public class Destinations
    {
        public int Id { get; set; }

        public int IdTask { get; set; }

        public string DestinationType { get; set; }

        public string Destination { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationUser { get; set; }

        public string DestinationPassword { get; set; }

        public string Port { get; set; }
    }
}
