using System;
using System.Linq;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(Sum(nums, 0));
        }

        private static int Sum(int[] nums, int i)
        {
            if (i == nums.Length - 1)
            {
                return nums[i];
            }

            return nums[i] + Sum(nums, i + 1);
        }
    }
}