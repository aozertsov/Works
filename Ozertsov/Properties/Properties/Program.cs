using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Prop p = new Prop();
            p.Work = 7;
            Console.WriteLine(p.Work);
            Arr arr = new Arr();
            arr[2] = 1;
            Console.WriteLine(arr[0] + arr[2]);
        }
    }

    class Prop
    {
         private int arrg;

        public int Work
        {
            get {return ++arrg;}
            set { arrg = value;}
        }
    }

    class Arr
    {
        private int[] array = new int[3];

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }
}

class Xyz
{
    public Xyz(int length)
    {
        int[] a = new int[length];
    }
}