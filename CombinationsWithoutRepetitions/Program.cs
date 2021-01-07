using System;

namespace CombinationsWithoutRepetitions
{
    class Program
    {
        private static string[] elements;
        private static int k;
        private static string[] result;
        static void Main()
        {
            elements = Console.ReadLine().Split(' ');
            k = int.Parse(Console.ReadLine());
            result = new string[k];

            GenerateCombinations(0, 0);
        }

        private static void GenerateCombinations(int index, int startFrom)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = startFrom; i < elements.Length; i++)
            {
                result[index] = elements[i];
                GenerateCombinations(index + 1, i + 1);
            }
        }
    }
}
