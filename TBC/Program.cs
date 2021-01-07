using System;

namespace TBC
{
    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static int result;
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            ReadMatrix(rows, cols);

            visited = new bool[rows, cols];

            result = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (!IsInMatrix(r, c) || visited[r, c] || matrix[r, c] != 't')
                    {
                        continue;
                    }
                    FindTunnels(r, c);
                    result++;
                }
            }

            Console.WriteLine(result);
        }

        private static void FindTunnels(int row, int col)
        {
            if (!IsInMatrix(row, col) || visited[row, col] || matrix[row, col] != 't')
            {
                return;
            }

            visited[row, col] = true;

            FindTunnels(row - 1, col);
            FindTunnels(row - 1, col + 1);
            FindTunnels(row, col + 1);
            FindTunnels(row + 1, col + 1);
            FindTunnels(row + 1, col);
            FindTunnels(row + 1, col - 1);
            FindTunnels(row, col - 1);
            FindTunnels(row - 1, col - 1);
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
        }
    }
}
