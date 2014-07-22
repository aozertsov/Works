using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Rectangle:Figure
    {
        private int Length;
        private int Width;

        public Rectangle(string str, int l, int w)
        {
            Name = str;
            Length = l;
            Width = w;
        }

        public void Square()
        {
            Console.WriteLine(Length*Width);
        }
    }
}
