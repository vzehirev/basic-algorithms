using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numToFind = int.Parse(Console.ReadLine());

            Console.WriteLine(Find(numToFind, nums));
        }

        private static int Find(int numToFind, int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var middle = (right + left) / 2;

                if (nums[middle] == numToFind)
                {
                    return middle;
                }

                if (nums[middle] > numToFind)
                {
                    right = middle - 1;
                }

                if (nums[middle] < numToFind)
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
    }
}
