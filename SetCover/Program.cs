using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main()
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var sets = new List<int[]>();
            List<int[]> result;

            while (true)
            {
                var set = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sets.Add(set);
                sets = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).ToList();

                result = Check(new List<int>(universe), sets);
                if (result.Count > 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Sets to take ({result.Count}):");
            foreach (var set in result)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }

        private static List<int[]> Check(List<int> universe, List<int[]> sets)
        {
            var result = new List<int[]>();

            foreach (var set in sets)
            {
                if (universe.Any(e => set.Contains(e)))
                {
                    foreach (var el in set)
                    {
                        universe.Remove(el);
                    }
                    result.Add(set);
                    if (universe.Count == 0)
                    {
                        return result;
                    }
                }
            }
            return new List<int[]>();
        }
    }
}
