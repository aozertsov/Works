using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator {
    using System.Collections;
    using System.Collections.Specialized;

    class Program {
        static void Main(string[] args) {
            int[] a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach (var VARIABLE in GetGollection(a)) {
                Console.WriteLine(VARIABLE);
            }
        }

        static IEnumerable GetGollection(int[] a) {

            //via LINQ
            var query = from element in a
                where element%2 == 1
                select element*element;
            return query;

            //via yield
//            foreach (var element in a) {
//                if (element%2 == 1)
//                    yield return Math.Pow(element, 2);
//            }
        }
    }
}
