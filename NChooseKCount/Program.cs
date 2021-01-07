using System;

namespace NChooseKCount
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(Solve(n, k));
        }

        private static int Solve(int n, int k)
        {
            if (n == 0 || n == 1 || k == 0 || k == n)
            {
                return 1;
            }

            return Solve(n - 1, k - 1) + Solve(n - 1, k);
        }
    }
}
