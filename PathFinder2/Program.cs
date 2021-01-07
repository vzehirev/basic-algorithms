using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder2
{
    class Program
    {
        private static SortedDictionary<int, List<int>> graph;
        private static SortedDictionary<int, List<int>> paths;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            ReadGraph(n);

            var p = int.Parse(Console.ReadLine());

            ReadPaths(p);

            foreach (var path in paths.Values)
            {
                var isValid = true;
                for (int s = 0; s < path.Count - 1; s++)
                {
                    var node = path[s];
                    if (!graph.ContainsKey(node) || !graph[node].Contains(path[s + 1]))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static void ReadPaths(int p)
        {
            paths = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < p; i++)
            {
                var path = Console.ReadLine().Split().Select(int.Parse);
                paths.Add(i, new List<int>());
                paths[i].AddRange(path);
            }
        }

        private static void ReadGraph(int n)
        {
            graph = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());

                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var children = input.Split().Select(int.Parse);
                    graph[i].AddRange(children);
                }
            }
        }
    }
}
