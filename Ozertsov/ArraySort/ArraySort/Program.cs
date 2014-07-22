using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p = new int[3];
            for (int l = 0; l < p.Length; l++)
            {
                p[l] = Int16.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            BaseSort.PasteSort(p);
            for (int l = 0; l < p.Length; l++)
            {
                Console.WriteLine(p[l]);
            }
        }
    }
}
