using System;
using System.Collections.Generic;
using System.Text;

namespace _8Queens
{
    class Program
    {
        private static int rows = 8;
        private static int cols = 8;
        private static bool[,] board = new bool[rows, cols];
        private static int queens = 0;
        private static List<int> occRows = new List<int>();
        private static List<int> occCols = new List<int>();
        private static List<int> occLD = new List<int>();
        private static List<int> occRD = new List<int>();

        static void Main()
        {
            FindSolutions(0);
        }

        private static void FindSolutions(int row)
        {
            if (queens == 8)
            {
                PrintBoard();
            }

            for (int col = 0; col < cols; col++)
            {
                if (CanPlace(row, col))
                {
                    PutQueen(row, col);
                    MarkAsOcc(row, col);
                    FindSolutions(row + 1);
                    RemoveQueen(row, col);
                    UnmarkAsOcc(row, col);
                }
            }
            return;
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                var rowAsStr = new StringBuilder();
                for (int col = 0; col < cols; col++)
                {
                    var toApp = board[row, col] ? "* " : "- ";
                    rowAsStr.Append(toApp);
                }
                Console.WriteLine(rowAsStr.ToString().Trim());
            }
                Console.WriteLine();
        }

        private static bool CanPlace(int row, int col)
        {
            return !occRows.Contains(row) && !occCols.Contains(col) && !occLD.Contains(col - row) && !occRD.Contains(row + col) && row >= 0 && row < rows && col >= 0 && col < cols;
        }

        private static void PutQueen(int row, int col)
        {
            queens++;
            board[row, col] = true;
        }

        private static void MarkAsOcc(int row, int col)
        {
            occRows.Add(row);
            occCols.Add(col);
            occLD.Add(col - row);
            occRD.Add(row + col);
        }

        private static void RemoveQueen(int row, int col)
        {
            queens--;
            board[row, col] = false;
        }

        private static void UnmarkAsOcc(int row, int col)
        {
            occRows.Remove(row);
            occCols.Remove(col);
            occLD.Remove(col - row);
            occRD.Remove(row + col);
        }
    }
}
