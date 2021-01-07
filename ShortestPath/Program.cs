using System;
using System.Collections.Generic;

namespace ShortestPath
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, int> parents;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            ReadGraph(nodes, edges);

            var src = int.Parse(Console.ReadLine());
            var dest = int.Parse(Console.ReadLine());

            FindShortestPath(src, dest);

            var result = new Stack<int>();
            result.Push(dest);

            var endNode = dest;

            while (endNode != src)
            {
                result.Push(parents[endNode]);
                endNode = parents[endNode];
            }

            Console.WriteLine("Shortest path length is: " + (result.Count - 1));
            Console.WriteLine(string.Join(' ', result));
        }

        private static void FindShortestPath(int src, int dest)
        {
            var queue = new Queue<int>();

            queue.Enqueue(src);

            parents = new Dictionary<int, int>();
            parents.Add(src, -1);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == dest)
                {
                    return;
                }

                foreach (var child in graph[node])
                {
                    if (graph.ContainsKey(child) && !parents.ContainsKey(child))
                    {
                        queue.Enqueue(child);
                        parents[child] = node;
                    }
                }
            }
        }

        private static void ReadGraph(int nodes, int edges)
        {
            graph = new Dictionary<int, List<int>>();

            for (int i = 1; i <= edges; i++)
            {
                var input = Console.ReadLine().Split();

                var src = int.Parse(input[0]);
                var dest = int.Parse(input[1]);

                if (!graph.ContainsKey(src))
                {
                    graph[src] = new List<int>();
                }
                graph[src].Add(dest);
            }
        }
    }
}
