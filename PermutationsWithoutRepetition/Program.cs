using System;
using System.Linq;

namespace PermutationsWithoutRepetition
{
    class Program
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ');

            var result = new string[elements.Length];

            GeneratePerms(elements, result, 0);
        }

        private static void GeneratePerms(string[] elements, string[] result, int index)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int element = 0; element < elements.Length; element++)
            {
                if (!result.Contains(elements[element]))
                {
                    result[index] = elements[element];
                GeneratePerms(elements, result, index + 1);
                result[index] = null;
                }
            }
        }
    }
}
