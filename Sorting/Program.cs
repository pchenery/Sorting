
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] Random1 = new int[25000];
            arrayGenerate(Random1, 2);
            int[] Random2 = new int[50000];
            arrayGenerate(Random2, 2);
            int[] Sorted1 = new int[25000];
            sortedGenerate(Sorted1);
            int[] Sorted2 = new int[75000];
            sortedGenerate(Sorted2);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            selectionSort(Random1);
            stopWatch.Stop();
            showTiming("Selection Sort Random", Random1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            selectionSort(Random2);
            stopWatch.Stop();
            showTiming("Selection Sort Random", Random2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            arrayGenerate(Random1, 2);
            arrayGenerate(Random2, 2);

            stopWatch.Start();
            insertionSort(Random1);
            stopWatch.Stop();
            showTiming("Insertion Sort Random", Random1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(Random2);
            stopWatch.Stop();
            showTiming("Insertion Sort Random", Random2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(Sorted1);
            stopWatch.Stop();
            showTiming("Insertion Sort Sorted", Sorted1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            insertionSort(Sorted2);
            stopWatch.Stop();
            showTiming("Insertion Sort Sorted", Sorted2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            arrayGenerate(Random1, 2);
            arrayGenerate(Random2, 2);

            stopWatch.Start();
            mergeSort(Random1, 0, Random1.Length - 1);
            stopWatch.Stop();
            showTiming("Merge Sort Random", Random1.Count(), stopWatch.Elapsed.TotalMilliseconds);

            stopWatch.Start();
            mergeSort(Random2, 0, Random2.Length - 1);
            stopWatch.Stop();
            showTiming("Merge Sort Random", Random2.Count(), stopWatch.Elapsed.TotalMilliseconds);

            //DisplayResults(msRandom1);
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

        public static void selectionSort(int[] numbers)
        {
            int min, temp;
            int size = numbers.Count();

            for (int i = 0; i < size - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }
        }

        public static void insertionSort(int[] numbers)
        {
            int j, key;
            for (int i = 0; i < numbers.Length; i++)
            {
                key = numbers[i];
                j = i - 1;
                while (j >= 0 && key < numbers[j])
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
        }

        public static void mergeSort(int[] numbers, int left, int right)
        {
            int mid;
            if (right >left)
            {
                mid = (right + left) / 2;
                mergeSort(numbers, left, mid);
                mergeSort(numbers, mid + 1, right);
                merge(numbers, left, mid + 1, right);
            }
        }

        public static void merge(int[] numbers, int left, int mid, int right)
        {
            int[] tmp = new int[numbers.Length];
            int i, left_end, elements, tmpPos;
            left_end = (mid - 1);
            tmpPos = left;
            elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                {
                    tmp[tmpPos++] = numbers[left++];
                }
                else
                {
                    tmp[tmpPos++] = numbers[mid++];
                }
            }

            while (left <= left_end)
            {
                tmp[tmpPos++] = numbers[left++];
            }

            while (mid <= right)
            {
                tmp[tmpPos++] = numbers[mid++];
            }

            for (i = 0; i < elements; i++)
            {
                numbers[right] = tmp[right];
                right--;
            }
        }
    }
}
