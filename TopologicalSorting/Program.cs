using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class Program
    {
        private static List<KeyValuePair<string, List<string>>> graph;
        private static List<string> result;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            ReadGraph(n);

            result = new List<string>();

            for (int i = 0; i < graph.Count; i++)
            {
                var contained = false;

                foreach (var kvp in graph)
                {
                    if (kvp.Value.Contains(graph[i].Key))
                    {
                        contained = true;
                    }
                }
                if (contained)
                {
                    continue;
                }
                else
                {
                    result.Add(graph[i].Key);
                    graph.RemoveAt(i);
                    i = -1;
                }
            }

            //TopSort(graph.Keys.First());

            if (result.Count == n)
            {
                Console.WriteLine("Topological sorting: " + string.Join(", ", result));
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        //private static void TopSort(string node)
        //{
        //    if (result.Contains(node))
        //    {
        //        return;
        //    }

        //    foreach (var child in graph[node])
        //    {
        //        if (graph[child].Contains(node))
        //        {
        //            return;
        //        }

        //        TopSort(child);
        //    }

        //    result.Add(node);
        //}

        private static void ReadGraph(int n)
        {
            graph = new List<KeyValuePair<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("->");
                var node = input[0].Trim();
                var children = input[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim());
                graph.Add(new KeyValuePair<string, List<string>>(node, new List<string>()));
                graph[i].Value.AddRange(children.Where(c => !string.IsNullOrWhiteSpace(c)));
            }
        }
    }
}
