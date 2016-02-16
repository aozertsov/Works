using System;
using System.Threading.Tasks;

namespace ParallelStart
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] ParallelVectorNumberMult(int[] a, int multiplicator)
        {
            Parallel.For(0, a.Length, i => a[i] *= multiplicator);
            return a;
        }

        static int[] VectorNumberMult(int[] a, int multiplicator)
        {
            for (int i = 0; i < a.Length; )
            {
                a[i++] *= multiplicator;
            }
            return a;
        }

        static int[] VectorNumberMultThred(int[] a, int multiplicator)
        {
            int kernel = Environment.ProcessorCount;
            int length = a.Length;

            Thread[] threads = new Thread[kernel];
            for (int i = 0; i < kernel;i++)
                threads[i] = new Thread((object o) => {
                    int[] b = (int[]) o;
                    for(int k = b[0]; k < b[1]; k++)
                    {
                        a[k] *= b[2];
                    }
                });

            int numelements = length / kernel;

            for (int i = 0; i < kernel - 1; i++)
            {
                threads[i].Start(new int[] {numelements * i, numelements * i + numelements, multiplicator});
            }
            threads[kernel-1].Start(new int[] { numelements * (kernel - 1), a.Length, multiplicator });

            foreach (var thread in threads)
            {
                thread.Join();
            }
            return a;
        }

        static int[,] MatrixMultThread(int[,] a, int[,] b)
        {
            int[,] result = new int[a.GetUpperBound(0) + 1,b.GetUpperBound(1) + 1];
            if (a.GetUpperBound(1) == b.GetUpperBound(0))
            {
                int kernel = a.GetUpperBound(1) <= Environment.ProcessorCount ? a.GetUpperBound(1) : Environment.ProcessorCount;
                Thread[] threads = new Thread[kernel];
                for (int i = 0; i < kernel; i++)
                {
                    threads[i] = new Thread((object o) =>
                    {
                        int element = (int) o;
                        do
                        {
                            for (int k = 0; k <= b.GetUpperBound(1); k++)
                            {
                                for (int j = 0; j <= b.GetUpperBound(0); j++)
                                {
                                    result[element, j] += a[element, k] * b[k, j];
                                }
                            }
                            element += kernel;
                        }
                        while (element <= a.GetUpperBound(0));
                    });
                    threads[i].Start(i);
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }
                return result;
            }
            throw new ArgumentException();
        }

        static int[,] MatrixMult(int[,] a, int[,] b)
        {
            if(a.GetUpperBound(1) == b.GetUpperBound(0))
            {
                int[,] result = new int[a.GetUpperBound(0) + 1, b.GetUpperBound(1) + 1];
                for(int i = 0; i <= a.GetUpperBound(1); i++)
                {
                    for(int k = 0; k <= b.GetUpperBound(1); k++)
                    {
                        for(int j = 0; j <= b.GetUpperBound(0); j++)
                        {
                            result[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return result;
            }
            throw new ArgumentException("");
        }
    }
}
