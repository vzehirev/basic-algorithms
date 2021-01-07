using System;
using System.Linq;

namespace ReverseArray
{
    class Program
    {
        private static int[] arr;
        static void Main()
        {
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Reverse(arr, 0);
            Console.WriteLine(string.Join(' ', arr));
        }

        private static void Reverse(int[] arr, int startFrom)
        {
            if (startFrom >= arr.Length / 2)
            {
                return;
            }

            var temp = arr[startFrom];
            arr[startFrom] = arr[arr.Length - startFrom - 1];
            arr[arr.Length - startFrom - 1] = temp;
            Reverse(arr, startFrom + 1);
        }
    }
}
