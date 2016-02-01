using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate void Puk(int n);
    delegate string Pert (string str, string str1);
    delegate string del(string str, string str1);
    delegate string pel(ref string st);
    
    class Program
    {
        event Puk SomethEvent;
        void OnSomethEvent(int n)
        {
            if (SomethEvent != null)
                SomethEvent(n);
        }
        static void Main(string[] args)
        {
            Program events = new Program();
            string qw = "qwerty  ";
            Console.ReadLine();
            //лямбда выражение
            del rt = (qwer, str1) => qwer + str1;
            qw = rt(qw, "123");
            Console.WriteLine(qw);
            rt += Strings.StringConcat;
            qw = rt(qw, "1");
            Console.WriteLine("modificated: " + qw);
            //Strings st = new Strings(qw);
            //Console.WriteLine(st.str);
            pel del = new pel(Strings.StStringDouble);
            Console.WriteLine("resultdouble = " + del(ref qw));
            Console.WriteLine(qw);
            del += Strings.StStringDeleteSpace;
            //Несмотря на изменение, нужно передавать ссылку, иначе, для каждого метода будет use изначальные данные
            Console.WriteLine("result = " + del(ref qw));
            Console.ReadLine();
            Strings evt = new Strings("qw");
            evt.SomeEvent += Strings.StringConcat;
            evt.OnSomeEvent(qw, qw);
            events.SomethEvent += n => { Console.WriteLine("это событие вывело число " + n); };
            events.OnSomethEvent(3);
        }
    }
}
