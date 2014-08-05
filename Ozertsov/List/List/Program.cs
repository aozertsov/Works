using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            Lst port = new Lst(576);
            Lst port1 = new Lst(571);
            Console.WriteLine(port);
            Console.WriteLine(port1);
            Console.WriteLine(port + port1);
        }
    }
}
