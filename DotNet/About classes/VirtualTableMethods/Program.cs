using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualTableMethods {
    interface IA {
        void Write(string s);
    }

    class A : IA {
        public static void Writes(string s) {
            Console.WriteLine($"В класс А передано значение {s}");
        }

        public virtual void Write(string s) {
            Console.WriteLine($"В класс А передано значение {s}");
        }
    }

    class B : A {
        public void Write(string s) {
            Console.WriteLine($"В класс B передано значение {s}");
        }
    }

    class Program {
        static void Main(string[] args) {
            IA a = new B();
            A b = new B();
            B c = new B();
            b.Write("aaa");
            a.Write("AAA");
            c.Write("aAa");
        }
    }
}
