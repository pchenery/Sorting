
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Program
    {
        int[] Random1 = new int[10000];

        public static void Main(string[] args)
        {
            int[] Random20 = new int[] { 12,7,19,3,15,18,9,5,16,4,11,13,2,10,1,6,20,8,14,17 };
            int[] Random40 = new int[] { 31,19,39,2,21,16,34,12,5,15,27,33,18,9,3,23,24,7,38,26,4,32,40,11,35,28,13,22,10,1,29,25,6,20,30,8,36,14,17,37 };
            int[] Random1 = new int[10000];
            arrayGenerate(Random1, 2);
            int[] Random2 = new int[20000];
            arrayGenerate(Random2, 2);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            selectionSort(Random1);
            stopWatch.Stop();
            showTiming("Selection Sort", Random1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            selectionSort(Random2);
            stopWatch.Stop();
            showTiming("Selection Sort", Random2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            //DisplayResults(Random1);
        }

        public static void showTiming(string name, int size, double time)
        {
            Console.WriteLine("{0} Run Time (ms) size {1} = {2} ", name, size, time.ToString());
            Console.ReadLine();
        }

        public static void arrayGenerate(int[] data, int Seed)
        {
            Random r = new Random(Seed);
            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = r.Next();
            }
        }

        public static void DisplayResults(int[] a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        public static void selectionSort(int[] a)
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
