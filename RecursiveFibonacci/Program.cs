using System;
using System.Collections.Generic;

namespace RecursiveFibonacci
{
    class Program
    {
        private static Dictionary<int, int> fibs = new Dictionary<int, int>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(n));
        }

        private static int Fib(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n == 1)
            {
                return 1;
            }

            if (fibs.ContainsKey(n))
            {
                return fibs[n];
            }

            var res = Fib(n - 1) + Fib(n - 2);

            fibs[n] = res;

            return res;
        }
    }
}
