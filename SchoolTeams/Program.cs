using System;
using System.Collections.Generic;

namespace SchoolTeams
{
    class Program
    {
        private static string[] girls;
        private static string[] boys;
        private static List<string> girlsCombinations = new List<string>();
        private static List<string> boysCombinations = new List<string>();
        private static string[] girlsCombination = new string[3];
        private static string[] boysCombination = new string[2];

        static void Main()
        {
            girls = Console.ReadLine().Split(", ");
            boys = Console.ReadLine().Split(", ");

            GenerateGirlsCombinations(0, 0);
            GenerateBoysCombinations(0, 0);

            for (int i = 0; i < girlsCombinations.Count; i++)
            {
                for (int j = 0; j < boysCombinations.Count; j++)
                {
                    Console.WriteLine($"{girlsCombinations[i]}, {boysCombinations[j]}");
                }
            }
        }

        private static void GenerateGirlsCombinations(int indexToFill, int startFrom)
        {
            if (indexToFill == girlsCombination.Length)
            {
                girlsCombinations.Add(string.Join(", ", girlsCombination));
                return;
            }

            for (int i = startFrom; i < girls.Length; i++)
            {
                girlsCombination[indexToFill] = girls[i];
                GenerateGirlsCombinations(indexToFill + 1, i + 1);
            }
        }

        private static void GenerateBoysCombinations(int indexToFill, int startFrom)
        {
            if (indexToFill == boysCombination.Length)
            {
                boysCombinations.Add(string.Join(", ", boysCombination));
                return;
            }

            for (int i = startFrom; i < boys.Length; i++)
            {
                boysCombination[indexToFill] = boys[i];
                GenerateBoysCombinations(indexToFill + 1, i + 1);
            }
        }
    }
}
