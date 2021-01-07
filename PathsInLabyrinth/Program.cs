using System;
using System.Collections.Generic;

namespace PathsInLabyrinth
{
    class Program
    {
        static List<char> dirs = new List<char>();

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var row = Console.ReadLine().ToCharArray();

                for (int c = 0; c < row.Length; c++)
                {
                    lab[r, c] = row[c];
                }
            }

            FindPaths(lab, 0, 0, 'S');
        }

        private static void FindPaths(char[,] lab, int row, int col, char dir)
        {
            if (!CanGo(lab, row, col))
            {
                return;
            }

            dirs.Add(dir);

            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", dirs).Replace('S', '\0'));
            }
            else
            {
                lab[row, col] = 'v';

                FindPaths(lab, row, col + 1, 'R');
                FindPaths(lab, row + 1, col, 'D');
                FindPaths(lab, row, col - 1, 'L');
                FindPaths(lab, row - 1, col, 'U');

                lab[row, col] = '-';
            }

            dirs.RemoveAt(dirs.Count - 1);
        }

        private static bool CanGo(char[,] lab, int row, int col)
        {
            return row >= 0 && row < lab.GetLength(0) && col >= 0 && col < lab.GetLength(1) && lab[row, col] != 'v' && lab[row, col] != '*';
        }
    }
}
