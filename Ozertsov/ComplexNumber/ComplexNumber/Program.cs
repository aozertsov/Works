using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex Z1 = new Complex(1,1);
            Complex Z2 = new Complex(2,2);
            int l = (Z1 * Z2).x;
            Console.WriteLine(l);
            //Console.WriteLine(Z3);
            Console.WriteLine(Z1);
            Console.WriteLine(Z1.Degree(Z1, 3));
            Console.WriteLine(Z1.Module(Z1));
            
        }
    }
}
