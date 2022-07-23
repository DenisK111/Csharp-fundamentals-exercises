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


            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }



            for (int i = 0; i < n; i++)
            {
                var children = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                if (children.Count() == 0)
                {
                    continue;
                }
                graph[i].AddRange(children);
            }
            var sb = new StringBuilder();
            int pairs = int.Parse(Console.ReadLine());
            for (int i = 0; i < pairs; i++)
            {
               
                var path = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var isPath = true;
                for (int node = 0; node < path.Length -1 ; node++)
                {
                    if (!graph[path[node]].Contains(path[node+1]))
                    {
                        isPath = false;
                        break;
                    }
                }

                var result = isPath ? "yes" : "no";
                sb.AppendLine(result);


            }

            Console.WriteLine(sb.ToString().TrimEnd());



        }

      







    }
}