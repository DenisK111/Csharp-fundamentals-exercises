using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    internal class Program
    {
        static List<int>[] graph;
        static int[] parents;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n + 1];
            parents = new int[n+1];
            Array.Fill(parents, -1);

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            int numberOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInput; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph[input[0]].Add(input[1]);
            }

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            BFS(startNode, endNode);
            var path = ReconstructPath(startNode, endNode);
            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(String.Join(" ",path));
        }

        private static Stack<int> ReconstructPath(int startNode, int endNode)
        {
            var path = new Stack<int>();
            int node = endNode;
            path.Push(node);
            while (parents[node] != -1)
            {
                path.Push(parents[node]);
                node = parents[node];
            }

            return path;
        }

        private static void BFS(int startNode,int endNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            while (queue.Any())
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    queue.Enqueue(child);
                    parents[child] = node;

                    if (child == endNode)
                    {
                        return;
                    }
                }
            }
        }
    }
}
