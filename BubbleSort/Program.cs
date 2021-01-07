using System;
using System.Linq;

namespace BubbleSort
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
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    var temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                    i = -1;
                }
            }
        }
    }
}
