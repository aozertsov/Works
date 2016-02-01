using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    
    class Strings
    {
        public event Pert SomeEvent;
        public void OnSomeEvent(string str1, string str2)
        {
            if (SomeEvent != null)
            {
                Console.WriteLine("EventResult: ");
                SomeEvent(str1, str2);
            }
        }

        public string str;
        public Strings(string stri)
        {
            str = stri;
        }
        string StringMo()
        {
            str += "  qwerty ";
            return str;
        }
        public static string StStringDouble(ref string str)
        {
            str += str;
            return str;
        }
        public static string StStringDeleteSpace(ref string str)
        {
            string str1 = "";
            foreach (char ch in str)
            {
                if (ch != ' ')
                {
                    str1 += ch;
                }
            }
            str = str1;
            return str;
        }
        public static string StringConcat(string str1, string str2)
        {
            return str1 + str2 + str1;
        }
    }
}
