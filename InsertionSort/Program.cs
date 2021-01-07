using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Sort(nums);

            Console.WriteLine(string.Join(' ', nums));
        }

        private static void Sort(List<int> nums)
        {
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[j] > nums[i])
                        {
                            nums.Insert(j, nums[i]);
                            nums.RemoveAt(i + 1);
                            break;
                        }
                    }
                }
            }
        }
    }
}
