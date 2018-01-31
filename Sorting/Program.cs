
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Random20 = new int[] { 12,7,19,3,15,18,9,5,16,4,11,13,2,10,1,6,20,8,14,17 };
            int[] Random40 = new int[] { 31,19,39,2,21,16,34,12,5,15,27,33,18,9,3,23,24,7,38,26,4,32,40,11,35,28,13,22,10,1,29,25,6,20,30,8,36,14,17,37 };
            int[] Random1000 = new int[10000];
            arrayGenerate(Random1000, 2);
            int[] Random2000 = new int[20000];
            arrayGenerate(Random2000, 2);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            selectionSort(Random1000);
            stopWatch.Stop();
            double ts = stopWatch.Elapsed.TotalMilliseconds;

            DisplayResults(Random1000);
            Console.WriteLine("Run Time (ms) " + ts.ToString());
            Console.ReadLine();
        }

        static void arrayGenerate(int[] data, int Seed)
        {
            Random r = new Random(Seed);
            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = r.Next();
            }
        }

        static void DisplayResults(int[] a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        static void selectionSort(int[] a)
        {
            int min, temp;
            int size = a.Count();

            for (int i = 0; i < size - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }
    }
}
