using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    internal class Program
    {
        static bool[] visited;
        static List<int>[] graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            visited = new bool[n];

            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (input.Length > 0)
                {
                    graph[i] = new List<int>(input.Split().Select(int.Parse));
                }

                else
                {
                    graph[i] = new List<int>();
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    var component = new Queue<int>();

                    DFS(node, component);

                    if (component.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"Connected component: {string.Join(" ", component)}");

                }

            }


        }

        private static void DFS(int node,Queue<int> component)
        {

            if (!visited[node])
            {
                visited[node] = true;


                foreach (var item in graph[node])
                {
                    DFS(item, component);
                }
                component.Enqueue(node);
            }
            



        }
    }
}
