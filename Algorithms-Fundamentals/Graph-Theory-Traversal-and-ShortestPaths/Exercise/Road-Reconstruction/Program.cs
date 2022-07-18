using System;
using System.Collections.Generic;
using System.Linq;

namespace Road_Reconstruction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < streets; i++)
            {
                var input = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);

            }

            var edges = graph.SelectMany((list, index) => graph[index],
                (list, val) => $"{Array.IndexOf(graph, list)} - {val}").ToList();
            var count = 0;
                Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {



                var split = edge.Split(" - ");

                var source = int.Parse(split[0]);
                var dest = int.Parse(split[1]);
                if (results.ContainsKey(dest) && results[dest].Contains(source))
                {
                    continue;
                }

                graph[source].Remove(dest);
                graph[dest].Remove(source);
               
                bool isCyclic = BFS(graph, source, dest);
                if (!isCyclic)
                {
                    count++;
                    if (!results.ContainsKey(source))
                    {
                        results[source] = new List<int>();
                    }
                    results[source].Add(dest);
                    
                }
                graph[source].Add(dest);
                graph[dest].Add(source);
                
            }
            Console.WriteLine("Important streets:");
            foreach (var kvp in results)
            {
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"{kvp.Key} {item}");
                }
            }



        }
        private static bool BFS(List<int>[] graph, int source, int dest)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
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
