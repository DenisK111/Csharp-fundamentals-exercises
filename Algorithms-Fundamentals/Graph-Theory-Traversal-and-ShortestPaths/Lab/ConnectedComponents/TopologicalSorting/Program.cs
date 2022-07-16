using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    internal class Program
    {
        static Dictionary<string,List<string>> graph;
        static HashSet<string> visited;
        static LinkedList<string> sorted;
        static HashSet<string> cycles;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            sorted = new LinkedList<string>();
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("->",StringSplitOptions.RemoveEmptyEntries);

                if (input.Length > 1)
                {
                    graph[input[0].Trim()] = new List<string>(input[1].Trim().Split(", "));
                }

                else
                {
                    graph[input[0].Trim()] = new List<string>();
                }
            }
            var isCyclic = false;
            foreach (var node in graph.Keys)
            {
                try
                {
                DFS(node);

                }
                catch (Exception ex)
                {
                    isCyclic = true;
                    Console.WriteLine(ex.Message);
                    break;
                }
            }


            if (!isCyclic)
            {

                Console.WriteLine($"Topological sorting: {String.Join(", ", sorted)}");
            }
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }
            sorted.AddFirst(node);
            cycles.Remove(node);
        }
    }
}
