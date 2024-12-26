using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public record struct Edge
    {
        public int From;
        public int To;
        public int Weight;
    }

    public static class Graphs
    {
        public static readonly List<Edge> WeightedEdgeGraph = new List<Edge>()
        {
            new Edge() { From = 0, To = 1, Weight = 4 },
            new Edge() { From = 0, To = 2, Weight = 5 },            
            new Edge() { From = 0, To = 3, Weight = 9 },
            new Edge() { From = 1, To = 3, Weight = 2 },
            new Edge() { From = 2, To = 3, Weight = 20 },
            new Edge() { From = 2, To = 4, Weight = 7 },
            new Edge() { From = 3, To = 4, Weight = 8 },
            new Edge() { From = 4, To = 5, Weight = 12 },
            new Edge() { From = 6, To = 7, Weight = 8 },
            new Edge() { From = 6, To = 8, Weight = 10 },
            new Edge() { From = 7, To = 8, Weight = 7 },
        };

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

        public static void MSTKruskal(List<Edge> graph)
        {
            int[] parents = graph.Aggregate(Enumerable.Empty<int>(), (acc, el) => acc.Append(el.From).Append(el.To))
                .Distinct()
                .Order()
                .ToArray();                        
            

            graph.OrderBy(e => e.Weight).ForEach(edge =>
            {
                var rootFrom = FindRoot(edge.From);
                var rootTo = FindRoot(edge.To);

                if (rootFrom == rootTo) return;

                Console.WriteLine(edge);
                parents[rootFrom] = rootTo;
            });

            int FindRoot(int node)
            {
                while (parents[node] != node)
                {
                    node = parents[node];
                }
                return node;
            }
        }

        public static void MSTPrim(List<Edge> graph)
        {
            Dictionary<int,List<Edge>> dict = GraphToDctionary(graph);
            var visited = new bool[dict.Count];
            var priorityQueue = new PriorityQueue<Edge,int>();
            dict.Keys.Order().ForEach(Prim);            

            void Prim(int startNode)
            {
                if (visited[startNode]) return;
                var node = dict[startNode];
                visited[startNode] = true;
                node.ForEach(el => priorityQueue.Enqueue(el, el.Weight));
                while(priorityQueue.Count > 0)
                {
                    var smallestEdge = priorityQueue.Dequeue();
                    if (visited[smallestEdge.To]) continue;
                    Console.WriteLine(smallestEdge);
                    visited[smallestEdge.To] = true;
                    dict[smallestEdge.To].ForEach(el => priorityQueue.Enqueue(el,el.Weight));
                }
            }            
        }

        public static void Dijkstra(List<Edge> graph)
        {
            var dictGraph = GraphToDctionary(graph);
            var distances = Enumerable.Range(0,dictGraph.Count).Select((el) => el == 0 ? el : int.MaxValue).ToArray();
            var priorityQueue = new SortedSet<int>(Comparer<int>.Create((f, s) => distances[f] - distances[s]))
            {
                dictGraph.Keys.First()
            };
            while(priorityQueue.Count > 0)
            {
                var min = priorityQueue.Min;
                priorityQueue.Remove(min);

                dictGraph[min].ForEach(edge =>
                {
                    var otherNode = edge.From == min ? edge.To : edge.From;
                    if (distances[otherNode] == int.MaxValue)
                    {
                        priorityQueue.Add(otherNode);
                    }

                    var newDistance = distances[min] + edge.Weight;
                    if (newDistance < distances[otherNode])
                    {
                        distances[otherNode] = newDistance;    
                        priorityQueue = new SortedSet<int>(priorityQueue, Comparer<int>.Create((f, s) => distances[f] - distances[s]));
                    }
                });

            }

            distances.ForEach(Console.WriteLine);
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

        private static Dictionary<int,List<Edge>> GraphToDctionary(List<Edge> graph) =>        
            graph.Aggregate(new Dictionary<int, List<Edge>>(), (acc, edge) =>
            {
                if (!acc.ContainsKey(edge.From))
                {
                    acc.Add(edge.From, new List<Edge>());
                }
                if (!acc.ContainsKey(edge.To))
                {
                    acc.Add(edge.To, new List<Edge>());
                }
                acc[edge.From].Add(edge);
                return acc;
            });       
       
    }
}
