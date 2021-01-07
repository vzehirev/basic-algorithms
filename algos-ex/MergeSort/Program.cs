using System;
using System.Linq;

namespace MergeSort
{
    static class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            arr.MergeSort();

            Console.WriteLine(string.Join(' ', arr));
        }

        static void MergeSort(this int[] arr)
        {
            var arr1 = new int[arr.Length / 2];

            var arr2 = new int[arr.Length - arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr[arr1.Length + i];
            }

            if (arr1.Length > 1)
            {
                MergeSort(arr1);
            }

            if (arr2.Length > 1)
            {
                MergeSort(arr2);
            }

            int f = 0;
            int s = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (f == arr1.Length)
                {
                    for (int j = s; j < arr2.Length; j++)
                    {
                        arr[i++] = arr2[j];
                    }
                    break;
                }
                else if (s == arr2.Length)
                {
                    for (int j = f; j < arr1.Length; j++)
                    {
                        arr[i++] = arr1[j];
                    }
                    break;
                }
                if (arr1[f] < arr2[s])
                {
                    arr[i] = arr1[f];
                    f++;
                }
                else
                {
                    arr[i] = arr2[s];
                    s++;
                }
            }
        }
    }
}