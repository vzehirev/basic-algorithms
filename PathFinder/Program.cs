using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    class Program
    {
        private static SortedDictionary<int, List<int>> graph;
        private static SortedDictionary<int, List<int>> paths;
        private static Dictionary<int, int> parents;
        private static HashSet<int> visited;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            ReadGraph(n);

            var p = int.Parse(Console.ReadLine());

            ReadPaths(p);

            var result = new List<string>();

            foreach (var path in paths.Values)
            {
                visited = new HashSet<int>();
                parents = new Dictionary<int, int>();
                parents.Add(path.First(), -1);
                FindPaths(path.First(), path.Last());

                var currentLast = path.Last();
                var pathResult = new Stack<int>();

                while (currentLast >= 0)
                {
                    pathResult.Push(currentLast);
                    currentLast = parents[currentLast];
                }

                if (string.Join(' ', pathResult) == string.Join(' ', path))
                {
                    result.Add("yes");
                }
                else
                {
                    result.Add("no");
                }
            }

            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }

        private static void FindPaths(int src, int dest)
        {
            var queue = new Queue<int>();
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);

                if (node == dest)
                {
                    return;
                }

                foreach (var child in graph[node])
                {
                    if (parents.ContainsKey(child))
                    {
                        continue;
                    }
                    parents.Add(child, node);
                    queue.Enqueue(child);
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
