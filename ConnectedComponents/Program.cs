using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static List<int> tempResult;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var children = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                graph.Add(i, children);
            }

            visited = new HashSet<int>();

            for (int node = 0; node < graph.Count(); node++)
            {
                if (!visited.Contains(node))
                {
                    tempResult = new List<int>();
                    FindConnectedComponents(node);
                    Console.WriteLine("Connected component: " + string.Join(' ', tempResult));
                }
            }
        }

        private static void FindConnectedComponents(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);

                foreach (var child in graph[node])
                {
                    FindConnectedComponents(child);
                }
                tempResult.Add(node);
            }
        }
    }
}
