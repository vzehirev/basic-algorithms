using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(num));
        }

        private static int Factorial(int num)
        {
            if (num <= 0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }
    }
}
