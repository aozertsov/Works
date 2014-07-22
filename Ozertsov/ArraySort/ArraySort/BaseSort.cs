using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    class BaseSort
    {
        public static void BubbleSort(int[] arr)
        {
            int a = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = a; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int dop = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = dop;
                    }
                    else
                        a=0;
                }
            }
        }

        public static void PasteSort(int[] arr)
        {
            for (int i=1; i<arr.Length; i++)
            {
                int k = arr[i];
                for (int j = i-1; j>=0; j--)
                {
                    if (arr[j] > k)
                    {
                        arr[j+1] = arr[j];
                        if (j == 0)
                            arr[j] = k;
                    }
                    else
                    {
                        arr[j + 1] = k;
                        break;
                    }
                }
            }
        }

        public static void NeymanSort(int[] arr)
        {
            
            int n = (arr.Length % 2 == 0) ? arr.Length/2 : arr.Length/2 +1;

        }
    }
}
