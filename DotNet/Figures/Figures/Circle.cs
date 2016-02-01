using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Circle:Figure
    {
        private int Radius;
        public Circle()
        {
            Name = "circle";
            Radius = 0;
        }

        public Circle(int r)
        {
            Name = "circle";
            Radius = r;
        }

        public Circle(string str, int r)
        {
            Name = str;
            Radius = r;
        }

        public void Length()
        {
            Console.WriteLine(2*3.14*Radius);
        }

        public void Square()
        {
            Console.WriteLine(4*3.14*Radius*Radius);
        }
    }
}
