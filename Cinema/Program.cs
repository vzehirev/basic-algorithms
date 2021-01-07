using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Program
    {
        private static List<string> names;
        private static string[] result;

        static void Main()
        {
            names = Console.ReadLine().Split(", ").ToList();

            result = new string[names.Count];

            string command;

            while ((command = Console.ReadLine()) != "generate")
            {
                var nameAndPlace = command.Split(" - ");
                var name = nameAndPlace[0];
                var place = int.Parse(nameAndPlace[1]) - 1;
                result[place] = name;
                names.Remove(name);
            }

            Generate(0);
        }

        private static void Generate(int indexToPlaceOn)
        {
            if (indexToPlaceOn == result.Length)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            if (result[indexToPlaceOn] != null)
            {
                Generate(indexToPlaceOn + 1);
                return;
            }

            for (int i = 0; i < names.Count; i++)
            {
                if (result.Contains(names[i]))
                {
                    continue;
                }
                result[indexToPlaceOn] = names[i];
                Generate(indexToPlaceOn + 1);
                result[indexToPlaceOn] = null;
            }
        }
    }
}
