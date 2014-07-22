using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Figure
    {
        protected string Name;

        public Figure(string str)
        {
            Name = str;
        }
        public Figure()
        {
            Name = "";
        }
    }
}
