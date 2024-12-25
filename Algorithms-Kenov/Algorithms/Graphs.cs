using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Graphs
    {
        public static readonly List<int>[] DirectedGraph = new List<int>[]
        {
                new List<int> {1, 2},
                new List<int> {3, 4},
                new List<int> {5, 3},
                new List<int> {5},
                new List<int> {3 },
                new List<int> (),                
        };

        public static List<int>[] RepresentUndirectedGraph()
        {
            var graph = new List<int>[]
            {
                new List<int> {3, 6},
                new List<int> {2, 3, 4, 5, 6},
                new List<int> {1, 4, 5},
                new List<int> {0, 1, 5},
                new List<int> {1, 2, 6},
                new List<int> {1, 2, 3},
                new List<int> {0, 1, 4},
                new List<int> (),
                new List<int> {9 },
                new List<int> {8 },
            };

            return graph;
        }

        public static void BFS(List<int>[] graph)
        {
            bool[] visited = new bool[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                if (visited[i]) continue;
                Console.Write("Connected components: ");                
                Bfs(i);
                Console.WriteLine();
            }

            void Bfs(int n)
            {
                var queue = new Queue<int>();
                queue.Enqueue(n);
                visited[n] = true;

                while (queue.Count > 0)
                {
                    var element = queue.Dequeue();
                    Console.Write(element + " ");
                    foreach (var child in graph[element])
                    {
                        if (visited[child]) continue;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        public static void DFS(List<int>[] graph)
        {
            var visited = new bool[graph.Length];
            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i]) continue;
                Console.Write("Connected components: ");
                Dfs(i);
                Console.WriteLine();

            }

            void Dfs(int index)
            {
                if (visited[index]) return;
                visited[index] = true;
                foreach (var node in graph[index]) Dfs(node);
                Console.Write(index + " ");
            }

        }

        public static void TopologicalSort(List<int>[] graph)
        {
            var resultList = new List<int>();
            var graphDistribution = graph.SelectMany(x => x).Aggregate(new Dictionary<int,int>(),(acc,el) =>
            {
                if (acc.ContainsKey(el))
                {
                    acc[el]++;
                }
                else
                {
                    acc[el] = 1;
                }

                return acc;
            });
            var set = Enumerable.Range(0,graph.Length).Except(graphDistribution.Keys).ToHashSet(); 
            
            while(set.Count > 0)
            {
                var node = set.First();
                set.Remove(node);
                resultList.Add(node);                                
                graph[node].ForEach(el =>
                {
                    if (graphDistribution[el] > 1 ) 
                    {
                        graphDistribution[el]--;    
                    }

                    else
                    {
                        set.Add(el);
                        graphDistribution.Remove(el);
                    }
                });                
            }

            if (graphDistribution.Any())
            {
                Console.WriteLine("Cyclical Graph!");
                graphDistribution.ForEach(kv =>
                {
                    Console.WriteLine(kv.Key + "->" + kv.Value);
                });
            }
            else
            {
                resultList.ForEach(el => Console.Write(el + " "));
            }

            
        }
    }
}
