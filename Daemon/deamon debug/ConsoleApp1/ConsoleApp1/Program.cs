using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = Config.GetConfig(2);


            Console.WriteLine($"{config.idConfig},{config.Repeatable}");

            Console.ReadLine();

        }
    }
}
