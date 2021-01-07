using System;
using System.Collections.Generic;

namespace WordCruncher
{
    class Program
    {
        private static string[] strings;
        private static string output;
        private static List<string> result = new List<string>();
        private static HashSet<string> results = new HashSet<string>();
        private static Dictionary<string, int> occurences = new Dictionary<string, int>();

        static void Main()
        {
            strings = Console.ReadLine().Split(", ");
            output = Console.ReadLine();

            foreach (var str in strings)
            {
                if (!output.Contains(str))
                {
                    continue;
                }
                if (!occurences.ContainsKey(str))
                {
                    occurences.Add(str, 1);
                }
                else
                {
                    occurences[str] += 1;
                }
            }

            FindSolutions();

            foreach (var res in results)
            {
                Console.WriteLine(res);
            }
        }

        private static void FindSolutions()
        {
            if (string.Join("", result) == output)
            {
                results.Add(string.Join(' ', result));
                return;
            }

            for (int i = 0; i < strings.Length; i++)
            {
                if (output.StartsWith(string.Join("", result) + strings[i]) && occurences[strings[i]] > 0)
                {
                    result.Add(strings[i]);
                    occurences[strings[i]] -= 1;
                    FindSolutions();
                    occurences[strings[i]] += 1;
                    result.RemoveAt(result.Count - 1);
                }
            }
        }
    }
}
