using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsWithRepetition
{
    class Program
    {
        private static string[] elements;

        static void Main()
        {
            elements = Console.ReadLine().Split(' ');

            GeneratePerms(0);
        }

        private static void GeneratePerms(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            GeneratePerms(index + 1);
            var swapped = new HashSet<string> { elements[index] };
            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(index, i);
                    GeneratePerms(index + 1);
                    Swap(index, i);
                    swapped.Add(elements[i]);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
