using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations
{
    public static class ArrayManipulator
    {
        public static int[] RemoveDuplicatesWithoutLinq(this int[] arr)
        {
            var left = new List<int>();
            var right = new List<int>();
            var hashset = new HashSet<int>();

            for (int i = 0, j = arr.Length - 1; i <= j; i++, j--)
            {
                if (hashset.Add(arr[i]))
                {
                    left.Add(arr[i]);
                }

                if (hashset.Add(arr[j]))
                {
                    right.Add(arr[j]);
                }
            }

            left.AddRange(right);
            return left.ToArray();
        }
    }
}
