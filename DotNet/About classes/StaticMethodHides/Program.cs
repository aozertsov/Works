using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StaticMethodHides { 

    class Base {
        public static Base STMeth() {
            return new Base();
        }

        public virtual void Print() {
            WriteLine("Base");
        }
    }

    class Derived : Base {
        public static Derived STMeth() {
            return new Derived();
        }

        public override void Print() {
            WriteLine("Derived");
        }
    }
    class Program {
        static void Main(string[] args) {
            Derived a = (Derived) Derived.STMeth();
            Base bases = new Derived();
            string s = bases.GetType().Name;

            Base b = Derived.STMeth();
            b.Print();
        }
    }
}
