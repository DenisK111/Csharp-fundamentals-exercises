namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private static int deepestLevel;
        private static Tree<T> deepestNode;
       
        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children=new List<Tree<T>> (children);

            foreach (var child in _children)
            {
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count>0)
            {
                var node = queue.Dequeue();

                if (node.Key.Equals(child.Key))
                {
                    foreach (var kid in child.Children)
                    {
                        kid.Parent = node;
                        node._children.Add(kid);
                    }
                   
                   
                }
                foreach (var item in node._children)
                {
                    queue.Enqueue(item);
                }
            }


        }

        public ICollection<T> BfsPrint()
        {
            var node = this;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);

            List<T> values = new List<T>();
            while (queue.Count>0)
            {
                node = queue.Dequeue();
                values.Add(node.Key);
                foreach (var child in node._children)
                {
                    queue.Enqueue(child);
                }

            }


            return values;

        }

        public void AddParent(Tree<T> parent)
        {
            throw new NotImplementedException();
        }

        public string GetAsString()
        {
            return DfsPrint(0, this);
            
        }

        private string DfsPrint(int level,Tree<T> root)
        {
            
            var node = root;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string(' ', level) + node.Key);

         
            
            
            foreach (var item in node._children)
            {
                sb.AppendLine(DfsPrint(level+2, item));
            }

            return sb.ToString().TrimEnd();

        }

        public Tree<T> GetDeepestLeftomostNode()
        {

            var node = this;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(node);

            while (queue.Count>0)
            {
                node = queue.Dequeue();

                for (int i = node._children.Count-1; i >= 0; i--)
                {
                    queue.Enqueue(node._children[i]);
                }

            }

            return node;

          //бб  ResetStaticValues();
          //  var result = GetLeftMostNode(0, this);
           // ResetStaticValues();
            //return result;

        }

        private Tree<T> GetLeftMostNode(int level,Tree<T> root)
        {

            var node = root;

            if (level > deepestLevel)
            {
                deepestNode = node;
                deepestLevel = level;

            }

            foreach (var item in node._children)
            {
              node = GetLeftMostNode(level + 1, item);
            }

            return deepestNode;


        }






        public List<T> GetLeafKeys()
        {
            var node = this;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            var set = new SortedSet<T>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node._children.Count == 0)
                {
                    set.Add(node.Key);
                }

                foreach (var child in node._children)
                {
                    queue.Enqueue(child);

                }
            }

            return set.ToList();
           

        }

        public List<T> GetMiddleKeys()
        {
            var node = this;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            var set = new SortedSet<T>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node._children.Count > 0 && node.Parent!=null)
                {
                    set.Add(node.Key);
                }

                foreach (var child in node._children)
                {
                    queue.Enqueue(child);

                }
            }

            return set.ToList();

        }

        public List<T> GetLongestPath()
        {

            List <T> list = new List<T>();

            var node = GetDeepestLeftomostNode();

            while (node!=null)
            {
                list.Add(node.Key);
                node = node.Parent;
            }

            list.Reverse();
            return list;
            
            //ResetStaticValues();
            //var returned =  LongestPath(0, this);
            //var list = returned.Skip(returned.Count - (deepestLevel + 1));
            //ResetStaticValues();
            //return list.Reverse<T>().ToList();
        }

        private List<T> LongestPath(int level, Tree<T> root)
        {

            var node = root;
            var list = new List<T>();

           

            
            foreach (var child in node._children)
            {

                list.AddRange(child.LongestPath(level + 1, child));
            }

            if (level > deepestLevel)
            {
                deepestNode = node;
                deepestLevel = level;
                while (deepestNode != null)
                {
                    list.Add(deepestNode.Key);
                    deepestNode = deepestNode.Parent;
                }

            }


            return list;

        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var listOfChildren = GetLeafs();
            List<List<T>> toBeReturned = new List<List<T>>();

            foreach (var leaf in listOfChildren)
            {
                
                List<T> currList = new List<T>();
                var currLeaf = leaf;
                while (currLeaf != null)
                {
                    currList.Add(currLeaf.Key);
                    currLeaf = currLeaf.Parent;
                }
                

                if (currList.Select(x=>int.Parse(x.ToString())).Sum().Equals(sum))
                {
                    toBeReturned.Add(currList.Reverse<T>().ToList());
                }

            }
            return toBeReturned;

            

        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            /*   var node = this;

               List<Tree<T>> toBeReturned = new List<Tree<T>>();
               Queue<Tree<T>> queue = new Queue<Tree<T>>();
               queue.Enqueue(node);


               while (queue.Count > 0)
               {
                   int currSum = 0;
                   node = queue.Dequeue();
                   currSum += int.Parse(node.Key.ToString());
                   List<Tree<T>> children = new List<Tree<T>>();
                   foreach (var child in node._children)
                   {
                       currSum += int.Parse(child.Key.ToString());
                       children.Add(child);
                       queue.Enqueue(child);
                   }

                   if (currSum == sum)
                   {
                       toBeReturned.Add(new Tree<T>(node.Key, children.ToArray()));
                   }

               }


               return toBeReturned;*/
            List<Tree<T>> list = new List<Tree<T>>();
            SubTreesWithGivenSumDFS(sum, list, this);
            return list;
        
        }

        private int SubTreesWithGivenSumDFS(int targetSum,List<Tree<T>> list, Tree<T> node)
        {
            int currentSum = Convert.ToInt32(node.Key);
            foreach (var child in node._children)
            {
                currentSum += SubTreesWithGivenSumDFS(targetSum, list, child);
            }

            if (currentSum==targetSum)
            {
                list.Add(node);
            }

            return currentSum;

        }

        private void ResetStaticValues()
        {

            deepestLevel = -1;
            deepestNode = null;
        }

        private List<Tree<T>> GetLeafs()
        {
            var node = this;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            var set = new HashSet<Tree<T>>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node._children.Count == 0)
                {
                    set.Add(node);
                }

                foreach (var child in node._children)
                {
                    queue.Enqueue(child);

                }
            }

            return set.ToList();

        }
    }
}
