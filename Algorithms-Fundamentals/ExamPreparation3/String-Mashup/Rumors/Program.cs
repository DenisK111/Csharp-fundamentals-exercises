
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distance_Between_Vertices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[n + 1];

            for (int i = 1; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < pairs; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int from = int.Parse(input[0]);
                var to = int.Parse(input[1]);

                graph[from].Add(to);
                graph[to].Add(from);

            }
            var sb = new StringBuilder();
            int source = int.Parse(Console.ReadLine());
            for (int i = 1; i < graph.Length; i++)
            {
                if (source==i)
                {
                    continue;
                }
                HashSet<int> visited = new HashSet<int>();

                var end = i;
                var results = new List<int>();
                var length = GetLength(graph, results, source, end, visited, 0);

                if (length!=-1)
                {

                sb.AppendLine($"{source} -> {end} ({length})");
                }


            }

            Console.WriteLine(sb.ToString().TrimEnd());



        }

        private static int GetLength(List<int>[] graph, List<int> results, int start, int end, HashSet<int> visited, int level)
        {
            if (start == end)
                return level;

            if (visited.Contains(start))
            {
                return -1;
            }

           

            var result = 0;

            for (int i = 0; i < graph[start].Count; i++)
            {
                visited.Add(start);
                result = GetLength(graph, results, graph[start][i], end, visited, level + 1);
                results.Add(result);
                visited.Remove(start);
            }
            if (results.Where(x => x != -1).Any())
            {
                return results.Where(x => x != -1).Min();

            }
            return -1;
        }







    }
}