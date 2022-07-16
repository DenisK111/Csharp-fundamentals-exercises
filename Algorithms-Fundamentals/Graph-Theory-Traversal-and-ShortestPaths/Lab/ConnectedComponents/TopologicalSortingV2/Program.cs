using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSortingV2
{
    internal class Program
    {
        static Dictionary<string, List<string>> graph;
        static Dictionary<string, int> predecessorsCount;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            predecessorsCount = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {
            var input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length > 1)
                {
                    graph[input[0].Trim()] = new List<string>(input[1].Trim().Split(", "));
                }

                else
                {
                    graph[input[0].Trim()] = new List<string>();
                }
            }
            

            GetPredecessorCount();
            TopologicalSort();
        }

        private static void TopologicalSort()
        {
            var sorted = new List<string>();
            while (predecessorsCount.Count>0)
            {
                var node = predecessorsCount.FirstOrDefault(x => x.Value == 0);

                if (node.Key == null)
                {
                    break;
                }

                foreach (var child in graph[node.Key])
                {
                    predecessorsCount[child]--;
                }

                sorted.Add(node.Key);
                predecessorsCount.Remove(node.Key);

            }

            if (predecessorsCount.Any())
            {
                Console.WriteLine("Invalid topological sorting");
            }

            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ",sorted)}");
            }
        }

        private static void GetPredecessorCount()
        {
            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!predecessorsCount.ContainsKey(node))
                {
                    predecessorsCount[node] = 0;
                }

                foreach (var child in graph[node])
                {
                    if (!predecessorsCount.ContainsKey(child))
                    {
                        predecessorsCount[child] = 0;
                    }

                    predecessorsCount[child]++;
                }
            }
        }
    }
}
