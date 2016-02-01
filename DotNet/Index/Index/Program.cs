using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Adress.Adress Adre = new Adress.Adress("Russia", "SPB", "Botanichecskaya", 16, 412, "Alexander", "Ozertsov", 504198);
            Console.WriteLine(Adre.City);
        }
    }
}
