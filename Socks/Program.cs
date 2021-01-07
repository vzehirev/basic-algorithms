using System;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main()
        {
            var left = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var right = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var lcs = new int[left.Length + 1, right.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (left[r - 1] == right[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            Console.WriteLine(lcs[left.Length, right.Length]);
        }
    }
}
