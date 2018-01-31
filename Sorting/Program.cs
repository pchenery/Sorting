
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
            int[] ssRandom1 = new int[10000];
            arrayGenerate(ssRandom1, 2);
            int[] ssRandom2 = new int[20000];
            arrayGenerate(ssRandom2, 2);
            int[] isRandom1 = new int[10000];
            arrayGenerate(isRandom1, 2);
            int[] isRandom2 = new int[20000];
            arrayGenerate(isRandom2, 2);
            int[] msRandom1 = new int[10000];
            arrayGenerate(msRandom1, 2);
            int[] msRandom2 = new int[20000];
            arrayGenerate(msRandom2, 2);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            selectionSort(ssRandom1);
            stopWatch.Stop();
            showTiming("Selection Sort", ssRandom1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            selectionSort(ssRandom2);
            stopWatch.Stop();
            showTiming("Selection Sort", ssRandom2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(isRandom1);
            stopWatch.Stop();
            showTiming("Insertion Sort", isRandom1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(isRandom2);
            stopWatch.Stop();
            showTiming("Insertion Sort", isRandom2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(msRandom1);
            stopWatch.Stop();
            showTiming("Merge Sort", msRandom1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(msRandom2);
            stopWatch.Stop();
            showTiming("Merge Sort", msRandom2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            DisplayResults(isRandom1);
            Console.ReadLine();
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

        public static void sortedGenerate(int[] data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = i;
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

        public static void insertionSort(int[] a)
        {
            int j, key;
            for (int i = 0; i < a.Length; i++)
            {
                key = a[i];
                j = i - 1;
                while (j >= 0 && key < a[j])
                    //a[j] > key
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
        }
    }
}
