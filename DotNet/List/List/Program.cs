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
            Lst port = new Lst(2014);
            Lst port1 = new Lst(-1968);
            Console.WriteLine(port);
            Console.WriteLine(port1);
            Console.WriteLine(port * port1);
            Console.WriteLine(port * port1);
        }
    }
}
