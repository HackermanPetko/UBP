using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Destination
    {
        public int Id { get; set; }

        public int IdTask { get; set; }

        public string DestinationType { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationUser { get; set; }

        public string DestinationPassword { get; set; }

        public string FTPport { get; set; }
    }
}
