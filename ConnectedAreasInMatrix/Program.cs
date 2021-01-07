using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInMatrix
{
    class Area
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }
    }

    class Program
    {
        private static char[,] matrix;
        private static List<Area> areas = new List<Area>();

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowChars = Console.ReadLine().ToCharArray();

                for (int cell = 0; cell < matrix.GetLength(1); cell++)
                {
                    matrix[row, cell] = rowChars[cell];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var areaSize = FindArea(row, col);

                    if (areaSize != 0)
                    {
                        areas.Add(new Area
                        {
                            Row = row,
                            Col = col,
                            Size = areaSize
                        });
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");

            areas = areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col).ToList();

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static int FindArea(int row, int col)
        {
            if (!CanGo(row, col))
            {
                return 0;
            }

            matrix[row, col] = 'v';

            return 1 + FindArea(row - 1, col)
            + FindArea(row + 1, col)
            + FindArea(row, col - 1)
            + FindArea(row, col + 1);
        }

        private static bool CanGo(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] != '*' && matrix[row, col] != 'v' && matrix[row, col] == '-';
        }
    }
}
