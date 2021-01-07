using System;

namespace VariationsWithRepetition
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

            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                result[index] = elements[i];
                GenerateVariations(index + 1);
                result[index] = null;
            }
        }
    }
}