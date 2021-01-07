using System;
using System.Collections.Generic;
using System.Linq;

namespace CyclesInGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static bool result;

        static void Main()
        {
            ReadGraph();

            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            result = false;

            foreach (var node in graph.Keys)
            {
                cycles.Clear();
                try
                {

                    FindCycles(node);
                }
                catch (Exception)
                {
                    result = true;
                }
            }

            if (result)
            {
                Console.WriteLine("Acyclic: No");
            }
            else
            {
                Console.WriteLine("Acyclic: Yes");
            }
        }

        private static void FindCycles(string node)
        {
            var queue = new Queue<string>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (cycles.Contains(n))
                {
                    throw new Exception();
                }
                cycles.Add(n);

                foreach (var child in graph[n])
                {
                    if (graph.ContainsKey(child))
                    {

                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static void ReadGraph()
        {
            graph = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split('-');

                if (!graph.ContainsKey(tokens[0]))
                {
                    graph.Add(tokens[0], new List<string>());
                }
                graph[tokens[0]].Add(tokens[1]);

                input = Console.ReadLine();
            }
        }
    }
}
