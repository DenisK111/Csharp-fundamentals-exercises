namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;



        private int rootValue;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();

        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();


            foreach (var item in input)
            {
                int[] keyValue = item.Split().Select(int.Parse).ToArray();

                if (!edges.ContainsKey(keyValue[0]))
                {
                    edges[keyValue[0]] = new List<int>();
                }
                edges[keyValue[0]].Add(keyValue[1]);
            }

            bool isRoot = true;

            foreach (var key in edges.Keys)
            {
                foreach (var value in edges.Values)
                {
                    if (value.Contains(key))
                    {
                        isRoot = false;
                    }
                }
                //   7 

                //10 88  89  
            //54
            //20
          //55 190

                if (isRoot)
                {
                    rootValue = key;
                    break;
                }

                isRoot = true;
            }

            foreach (var item in edges)
            {
                List<Tree<int>> tres = new List<Tree<int>>();
                foreach (var value in item.Value)
                {
                    tres.Add(new Tree<int>(value));
                }
                Tree<int> tree = new Tree<int>(item.Key, tres.ToArray());
                nodesBykeys[tree.Key] = tree;
            }



            var mainTree = nodesBykeys[rootValue];
            nodesBykeys.Remove(rootValue);
           

            foreach (var item in nodesBykeys)
            {


                mainTree.AddChild(item.Value);


               

            }
           

            return mainTree;
        }



        public Tree<int> CreateNodeByKey(int key)
        {


            nodesBykeys[key] = new Tree<int>(key);


            return nodesBykeys[key];

        }

        public void AddEdge(int parent, int child)
        {

            Tree<int> tree = new Tree<int>(parent, new Tree<int>(child));
        }

        private Tree<int> GetRoot()
        {
            return nodesBykeys[rootValue];
        }
    }
}
