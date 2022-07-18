using System;
using System.Collections.Generic;
using System.Linq;

namespace Break_Cycles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();



            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ->", StringSplitOptions.RemoveEmptyEntries);


                string from = input[0];
                graph[from] = new List<string>();
                if (input.Length == 1)
                {
                    continue;
                }
                var to = input[1].Trim().Split();
                for (int i1 = 0; i1 < to.Length; i1++)
                {


                    graph[from].Add(to[i1]);
                }
            }

            var edges = graph.SelectMany(kvp => kvp.Value,
                (kvp, val) => $"{kvp.Key} - {val}").OrderBy(x=>x).ToList();

            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            var count = 0;
            foreach (var edge in edges)
            {

              

                var split = edge.Split(" - ");
                
                var source = split[0];
                var dest = split[1];

                if (results.ContainsKey(dest) && results[dest].Contains(source))
                {
                    continue;
                }

                graph[source].Remove(dest);
                graph[dest].Remove(source);
                bool isCyclic = BFS(graph, source, dest);
                if (isCyclic)
                {
                    count++;
                    if (!results.ContainsKey(source))
                    {
                        results[source] = new List<string>();
                    }
                    results[source].Add(dest);
                    continue;
                }
                graph[source].Add(dest);
                graph[dest].Add(source);
            }

            Console.WriteLine($"Edges to remove: {count}");
            foreach (var kvp in results)
            {
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"{kvp.Key} - {item}");
                }
                
            }
        }

        private static bool BFS(Dictionary<string, List<string>> graph, string source, string dest)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (visited.Contains(node))
                {
                    continue;
                }

                visited.Add(node);

                foreach (var child in graph[node])
                {
                    if (child == dest)
                    {
                        return true;
                    }

                    queue.Enqueue(child);

                  
                }
            }

            return false;
        }
    }
}
