using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<Tuple<int, int>> pairs;
        private static Dictionary<int, int> tempResult;
        private static Dictionary<string, int> finalResult;

        static void Main()
        {
            ReadGraph();

            FindShortestPaths();

            foreach (var res in finalResult)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }

        private static void FindShortestPaths()
        {
            finalResult = new Dictionary<string, int>();

            foreach (var pair in pairs)
            {
                tempResult = new Dictionary<int, int>();

                var src = pair.Item1;
                var dest = pair.Item2;

                var queue = new Queue<int>();

                queue.Enqueue(src);

                tempResult.Add(src, 0);

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();

                    if (node == dest)
                    {
                        break;
                    }

                    foreach (var child in graph[node])
                    {
                        if (!tempResult.ContainsKey(child) && graph.ContainsKey(child))
                        {
                            queue.Enqueue(child);
                            tempResult.Add(child, tempResult[node] + 1);
                        }
                    }
                }

                if (!tempResult.ContainsKey(dest))
                {
                    tempResult.Add(dest, -1);
                }
                finalResult.Add($"{{{src}, {dest}}}", tempResult[dest]);
            }
        }

        private static void ReadGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(input[0]);
                graph.Add(node, new List<int>());

                if (input.Length == 2)
                {
                    var children = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    graph[node].AddRange(children);
                }
            }

            pairs = new List<Tuple<int, int>>();

            for (int i = 0; i < p; i++)
            {
                var pair = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                pairs.Add(new Tuple<int, int>(pair[0], pair[1]));
            }
        }
    }
}
