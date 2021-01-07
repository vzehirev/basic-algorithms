using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Sort(nums);
            Console.WriteLine(string.Join(' ', nums));
        }

        private static void Sort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var minValue = int.MaxValue;
                var minIdx = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] <= minValue)
                    {
                        minValue = nums[j];
                        minIdx = j;
                    }
                }
                var temp = nums[i];
                nums[i] = nums[minIdx];
                nums[minIdx] = temp;
            }
        }
    }
}
