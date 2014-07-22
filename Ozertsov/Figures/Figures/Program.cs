using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure fig = new Figure("Some Figure");
            Circle cir = new Circle("circ", 3);
            Rectangle rec = new Rectangle("Rectangle", 2, 6);
            cir.Square();
            rec.Square();
            //переменной базового класса присваивается значение производного класса, обратное неверно(кажется)
            fig = cir;
        }
    }
}
