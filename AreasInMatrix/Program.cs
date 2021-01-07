using System;
using System.Collections.Generic;
using System.Linq;

namespace AreasInMatrix
{
    class Program
    {
        private static string[][] matrix;
        private static bool[][] visited;
        private static SortedDictionary<string, int> results;

        static void Main()
        {
            ReadMatrix();

            FindAreas();

            Console.WriteLine($"Areas: {results.Values.Sum()}");
            foreach (var result in results)
            {
                Console.WriteLine($"Letter '{result.Key}' -> {result.Value}");
            }
        }

        private static void FindAreas()
        {
            results = new SortedDictionary<string, int>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (visited[row][col])
                    {
                        continue;
                    }

                    DFS(row, col);

                    if (!results.ContainsKey(matrix[row][col]))
                    {
                        results.Add(matrix[row][col], 0);
                    }
                    results[matrix[row][col]]++;
                }
            }

        }

        private static void DFS(int row, int col)
        {
            if (visited[row][col])
            {
                return;
            }

            visited[row][col] = true;

            CallForChildren(row, col);
        }

        private static void CallForChildren(int row, int col)
        {
            var children = new List<Tuple<int, int>>();

            children.Add(new Tuple<int, int>(row - 1, col));
            children.Add(new Tuple<int, int>(row, col + 1));
            children.Add(new Tuple<int, int>(row + 1, col));
            children.Add(new Tuple<int, int>(row, col - 1));

            foreach (var child in children)
            {
                if (IsInMatrix(child) && matrix[row][col] == matrix[child.Item1][child.Item2])
                {
                    DFS(child.Item1, child.Item2);
                }
            }
        }

        private static bool IsInMatrix(Tuple<int, int> child)
        {
            return child.Item1 >= 0 && child.Item2 >= 0 && child.Item1 < matrix.Length && child.Item2 < matrix[0].Length;
        }

        private static void ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new string[rows][];
            visited = new bool[rows][];

            for (int row = 0; row < rows; row++)
            {
                var col = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToArray();
                matrix[row] = col;
                visited[row] = new bool[cols];
            }
        }
    }
}
