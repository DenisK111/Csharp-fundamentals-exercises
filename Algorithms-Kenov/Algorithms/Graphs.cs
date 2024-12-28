using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public record struct Edge
{
    public int From;
    public int To;
    public int Weight;
}

public static class Graphs
{
    public static readonly List<int>[] StronglyConnectedComponentsGraph =
    {
        new List<int> {1,11,13 },
        new List<int> {6 },
        new List<int> {0 },
        new List<int> {4 },
        new List<int> {3,6 },
        new List<int> {13 },
        new List<int> {0, 11 },
        new List<int> {12 },
        new List<int> {6, 11 },
        new List<int> {0 },
        new List<int> {4,6,10 },
        new List<int> {},
        new List<int> {7},
        new List<int> {2, 9},
    };

    public static readonly int[][] MaxFlowGraph =
    {
        [0,10,20,0,0,0],
        [0,0,2,3,8,0],
        [0,0,0,0,9,0],
        [0,0,0,0,0,10],
        [0,0,0,6,0,10],
        [0,0,0,0,0,0],
    }; 

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
            new List<int> {3},
            new List<int> {2, 3, 4, 5, 6},
            new List<int> {1, 4, 5},
            new List<int> {0, 1, 5},
            new List<int> {1, 2, 6},
            new List<int> {1, 2, 3},
            new List<int> {1, 4},                
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

    public static void StronglyConnectedComponents(List<int>[] graph)
    {
        var stronglyConnectedComponents = new List<List<int>>();    
        var reversedGraph = BuildReverseGraph(graph);
        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[graph.Length];
        graph.Select((_,i) => i).ForEach(DFS);
        visited = new bool[graph.Length];
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDFS(node);
            }
        }

        void DFS(int node)
        {
            if (visited[node]) return;
            visited[node] = true;
            graph[node].ForEach(DFS);
            stack.Push(node);
        }

        void ReverseDFS(int node)
        {
            if (visited[node]) return;
            visited[node] = true;
            stronglyConnectedComponents.Last().Add(node);
            reversedGraph[node].ForEach(ReverseDFS);
        }

        List<int>[] BuildReverseGraph(List<int>[] graph)
        {
            List<int>[] reversedGraph = Enumerable.Range(0, graph.Length).Select(_ => new List<int>()).ToArray();
            (from indexedNode in graph.Select((node, index) => (node, index))
             from child in indexedNode.node
             select (indexedNode.index, child))
            .ForEach(tuple => reversedGraph[tuple.child].Add(tuple.index));

            return reversedGraph;
        }

        Console.WriteLine("Strongly Connected Components: ");
        stronglyConnectedComponents.Select((n,i) => (n,i)).ForEach(ni =>            
            Console.WriteLine($"{ni.i} -> {string.Join(" ",ni.n)}"));        
    }

    public static void BiConnectivity(List<int>[] graph)
    {
        bool[] visited = new bool[graph.Length];
        int[] depths = new int[graph.Length];
        int[] lowpoints = new int[graph.Length];
        int[] parents = Enumerable.Range(0,graph.Length).ToArray();

        graph.Select((_, i) => i).ForEach(index =>
        {
            if (!visited[index]) FindArticulationPoints(index, 0);
        });
        

        void FindArticulationPoints(int node,int d)
        {
            visited[node] = true;
            depths[node] = d;
            lowpoints[node] = d;
            int childCount = 0;
            bool isArticulation = false;
            foreach (var childNode in graph[node])
            {
                if (!visited[childNode])
                {
                    parents[childNode] = node;
                    FindArticulationPoints (childNode, d + 1);
                    childCount++;
                    if (lowpoints[childNode] >= depths[node])
                    {
                        isArticulation = true;
                    }
                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[childNode]);
                }

                else if (childNode != parents[node])
                {
                    lowpoints[node] = Math.Min(lowpoints[node], depths[childNode]);
                }
            }

            if (parents[node] != node && isArticulation || parents[node] == node && childCount > 1)
            {
                Console.WriteLine(node);
            }
        }

    }    

    public static void MaxFlow(int[][] graph)
    {
        int[] parents = Enumerable.Repeat(-1, graph.Length).ToArray();

        int start = 0;
        var end = graph.Length -1;
        var maxFlow = 0;

        while (BFS(start, end))
        {
            var pathFlow = int.MaxValue;
            var currentNode = end;
            while (currentNode != start)
            {
                var prevNote = parents[currentNode];
                var currentFlow = graph[prevNote][currentNode];
                if (currentFlow > 0 && currentFlow < pathFlow)
                {
                    pathFlow = currentFlow;
                }

                currentNode = prevNote;
            }

            maxFlow += pathFlow;

            currentNode = end;
            while(currentNode != start)
            {
                var prevNote = parents[currentNode];
                graph[prevNote][currentNode] -= pathFlow;
                graph[currentNode][prevNote] += pathFlow;
                currentNode = prevNote;
            }                
        }

        Console.WriteLine(maxFlow);

        bool BFS(int start, int end)
        {
            var visited = new bool[graph.Length];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                for (int child = 0; child < graph[node].Length; child++)
                {
                    if (graph[node][child] > 0 && !visited[child])
                    {
                        queue.Enqueue(child);
                        parents[child] = node;
                        visited[child] = true;
                    }
                }
            }

            return visited[end];
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

public static class GraphExercises
{
    private record struct Edge
    {
        public int First;
        public int Second;
        public double Reliability;
    }

    public static void MostReliablePath()
    {           

        var nodesCount = int.Parse(Console.ReadLine()!.Split(' ')[1]);
        var paths = Console.ReadLine()!.Split(' ');
        var start = int.Parse(paths[1]);
        var end = int.Parse(paths[3]);
        var edgesCount = int.Parse(Console.ReadLine()!.Split(' ')[1]);       

        var graph = Enumerable.Range(0, nodesCount).ToDictionary(el => el, _ => new List<Edge>());
        int[] parents = graph.Keys.Order().ToArray();

        for (int i = 0; i < edgesCount; i++)
        {
            var input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            graph[input[0]].Add(new Edge
            {
                First = input[0],
                Second = input[1],
                Reliability = input[2] / 100.0
            });

            graph[input[1]].Add(new Edge
            {
                First = input[1],
                Second = input[0],
                Reliability = input[2] / 100.0
            });
        }

        var distances = Enumerable.Range(0, graph.Count).Select((el) => el == 0 ? 1 : double.MinValue).ToArray();
        var priorityQueue = new SortedSet<int>(Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])))
        {
            graph.Keys.First(k => k == start)
        };

        while(priorityQueue.Count > 0)
        {
            var min = priorityQueue.Min;
           var result =  priorityQueue.Remove(min);

            graph[min].ForEach(edge =>
            {
                var otherNode = edge.First == min ? edge.Second : edge.First;
                if (distances[otherNode] == double.MinValue)
                {
                    priorityQueue.Add(otherNode);
                }

                var newDistance = distances[min] * edge.Reliability;
                if (newDistance > distances[otherNode])
                {
                    distances[otherNode] = newDistance;
                    priorityQueue = new SortedSet<int>(priorityQueue, Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));
                    parents[otherNode] = min;
                }
            });           

        }
        

        Console.WriteLine(Math.Round(distances[end] * 100,2));
        List<int> path = new List<int>();
        var currentNode = end;
        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = parents[currentNode];
        }

        path.Add(start);
        path.Reverse();
        Console.WriteLine(string.Join(" -> ", path));
    }   
}
