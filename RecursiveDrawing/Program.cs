using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            Draw(num);
        }

        private static void Draw(int num)
        {
            if (num <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', num));

            Draw(num - 1);

            Console.WriteLine(new string('#', num));
        }
    }
}
