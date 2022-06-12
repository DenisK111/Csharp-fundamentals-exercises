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
            deepestLevel = -1;
            deepestNode = null;
            var result = GetLeftMostNode(0, this);
            deepestLevel = -1;
            deepestNode = null;
            return result;

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
           
        }

        private List<T> LongestPath(int level, Tree<T> root)
        {
            var node = root;
            var list = new List<T>();

            list.Add(this.Key);
            foreach (var child in node._children)
            {
                list.AddRange(LongestPath(level + 1, child));
            }

        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
