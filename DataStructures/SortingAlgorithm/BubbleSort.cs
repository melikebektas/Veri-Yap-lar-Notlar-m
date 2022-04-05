using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithm
{
    public class BubbleSort
    {
        public static void Sort<T> (T[] array)
            where T : IComparable
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j<array.Length-i-1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Sorting.Swap(array, j, j + 1);
                    }
                }
            }
        }
    }
}
