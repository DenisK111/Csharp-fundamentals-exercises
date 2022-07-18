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

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();



            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);


                int from = int.Parse(input[0]);
                graph[from] = new List<int>();
                if (input.Length == 1)
                {
                    continue;
                }
                var to = input[1].Split().Select(int.Parse).ToArray();
                for (int i1 = 0; i1 < to.Length; i1++)
                {


                    graph[from].Add(to[i1]);
                }
            }
            var sb = new StringBuilder();
            for (int i = 0; i < pairs; i++)
            {
                HashSet<int> visited = new HashSet<int>();
                

                var inputPairs = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var start = inputPairs[0];
                var end = inputPairs[1];
                var results = new List<int>();
                var length = GetLength(graph, results, start, end, visited, 0);
                sb.AppendLine($"{{{start}, {end}}} -> {length}");


            }

            Console.WriteLine(sb.ToString().TrimEnd());



        }

        private static int GetLength(Dictionary<int, List<int>> graph, List<int> results, int start, int end, HashSet<int> visited, int level)
        {
            if (start == end)
                return level;

           if (visited.Contains(start))
            {
                return -1;
            }

            visited.Add(start); 

            var result = 0;

            for (int i = 0; i < graph[start].Count; i++)
            {

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
