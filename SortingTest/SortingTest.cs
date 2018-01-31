using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTest
{
    public class SortingTest
    {
        [Test]
        public void SelectionSortTest()
        {
            int[] Random1 = new int[10000];
            Sorting.Program.arrayGenerate(Random1, 2);
            Sorting.Program.selectionSort(Random1);

            Assert.That(Random1, Is.Ordered);
        }
        [Test]
        public void InsertionSortTest()
        {
            int[] Random1 = new int[10000];
            Sorting.Program.arrayGenerate(Random1, 2);
            Sorting.Program.insertionSort(Random1);

            Assert.That(Random1, Is.Ordered);
        }
    }
}
