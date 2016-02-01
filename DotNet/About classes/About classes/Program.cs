using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace About_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //отличие методов Factorial и Factor в том, что один из них статический вызывается от класса, а нестатический вызывается от объекта класса
            Number P = new Number (4);
            Console.WriteLine(4);
            Console.WriteLine(Number.Factorial(4));
            Console.WriteLine(P.Factor(4));

        }
    }
    class Number
    {
        public int num;
        public Number(int x)
        {
            num = x;
        }
        public static int Factorial (int k)
        {
            if (k == 0)
                return 1;
            else
            {
                return (k * Factorial (k - 1));
            }
        }
        public int Factor (int k)
        {
            if (k == 0)
                return 1;
            else
            {
                return (k * Factorial(k - 1));
            }
        }
    }
}
