using System;
using System.Collections.Generic;
using System.Linq;

namespace Cycles_in_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            while (true)
            {

                var input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }
                var from = char.Parse(input[0]);
                graph[from] = new List<char>();
                if (input.Length == 1)
                {
                    continue;
                }
                var to = input[1].Split().Select(char.Parse).ToArray();
                for (int i1 = 0; i1 < to.Length; i1++)
                {

                    if (!graph.ContainsKey(to[i1]))
                    {
                        graph[to[i1]] = new List<char>();
                    }

                    graph[from].Add(to[i1]);
                }
                
            }
            bool cyclic = false;
            foreach (var node in graph.Keys)
            {
                cyclic = BFS(node,graph);
                if (cyclic)
                {
                    break;
                }
            }
            var output = "Yes";
            if (cyclic)
            {
                output = "No";
            }
            Console.WriteLine($"Acyclic: {output}");

        }

        private static bool BFS(char node, Dictionary<char, List<char>> graph)
        {
            var visited = new HashSet<char>();
            var queue = new Queue<char>();

            queue.Enqueue(node);

            while (queue.Any())
            {
                node = queue.Dequeue();

                if (visited.Contains(node))
                {
                    return true;
                }

                visited.Add(node);

                foreach (var child in graph[node])
                {
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
