using System;
using System.Linq;

namespace CombinationsWithRepetitionsEx
{
    class Program
    {
        private static int n;
        private static int k;

        private static int[] result;
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            result = new int[k];

            PrintCombs(0, 1);
        }

        private static void PrintCombs(int fillIndex, int startFrom)
        {
            if (fillIndex == result.Length)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = startFrom; i <= n; i++)
            {
                result[fillIndex] = i;
                PrintCombs(fillIndex + 1, i);
            }
        }
    }
}
