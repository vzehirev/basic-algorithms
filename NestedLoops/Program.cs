using System;

namespace NestedLoops
{
    class Program
    {
        private static int n;
        private static int[] result;
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            result = new int[n];

            Print(0);
        }

        private static void Print(int fillIndex)
        {
            if (fillIndex == n)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[fillIndex] = i;
                Print(fillIndex+1);
            }
        }
    }
}
