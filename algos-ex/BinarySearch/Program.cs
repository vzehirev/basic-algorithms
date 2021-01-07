using System;
using System.Linq;

namespace BinarySearch
{
    static class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var toFind = int.Parse(Console.ReadLine());

            Array.Sort(arr);

            Console.WriteLine(Search(arr, toFind, 0, arr.Length - 1));
        }

        private static int Search(int[] arr, int toFind, int start, int end)
        {
            var middleItem = arr[(start + end) / 2];

            if (start == end && middleItem.CompareTo(toFind) != 0)
            {
                return -1;
            }
            else if (middleItem.CompareTo(toFind) == 0)
            {
                return (start + end) / 2;
            }
            else if (middleItem.CompareTo(toFind) > 0)
            {
                return Search(arr, toFind, start, ((start + end) / 2) - 1);
            }
            else if (middleItem.CompareTo(toFind) < 0)
            {
                return Search(arr, toFind, ((start + end) / 2) + 1, end);
            }
            else if ((start + end) / 2 == end)
            {
                return -1;
            }

            return -1;
        }
    }
}