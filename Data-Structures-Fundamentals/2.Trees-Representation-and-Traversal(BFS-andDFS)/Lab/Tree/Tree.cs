namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();

        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();
        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            if (IsRootDeleted)
            {
                return new List<T>();
            }
            var node = this;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);
            var result = new List<T>();

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                result.Add(node.Value);

                foreach (var child in node._children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;

        }

        public ICollection<T> OrderDfs()
        {

            /// recursion
              var node = this;
              if (IsRootDeleted)
              {
                  return new List<T>();
              }
              var result = new List<T>();

              foreach (var child in node._children)
              {

                  result.AddRange(child.OrderDfs());
                  //result.Add(child.Value);

              }
              result.Add(node.Value);



              return result; 

            /// stack
            /// 

          /*  if (IsRootDeleted)
            {
                return new List<T>();
            }
            var node = this;
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(node);
            var result = new List<T>();

            while (stack.Count > 0)
            {
                node = stack.Pop();
                result.Add(node.Value);

                foreach (var child in node._children)
                {
                    stack.Push(child);
                }
            }

            return result;*/


        }

        public void AddChild(T parentKey, Tree<T> child)
        {

            var node = this;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);
            bool exists = false;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                if (node.Value.Equals(parentKey))
                {
                    exists = true;
                    node._children.Add(child);
                    break;
                }

                foreach (var nodeChild in node._children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            if (!exists)
                throw new ArgumentNullException();
           




        }

        public void RemoveNode(T nodeKey)
        {
            var node = this;
            bool exists = false;
            if (node.Value.Equals(nodeKey)) {

                throw new ArgumentException();
            }
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);


            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                if (node.Value.Equals(nodeKey))
                {
                    exists = true;
                    node.Parent._children.Remove(node);

                    break;
                }

                foreach (var nodeChild in node._children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            if (!exists)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> nullTree(Tree<T> tree)
        {
            tree = null;
            return tree;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var node = this;

              if (node.Value.Equals(firstKey) || node.Value.Equals(secondKey))
            {
                throw new ArgumentException();
            }

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);

            Tree<T> firstNode = null;
            Tree<T> secondNode = null;
      

            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                if (node.Value.Equals(firstKey))
                {
                    firstNode = node;

                }

                if (node.Value.Equals(secondKey))
                {
                    secondNode = node;
                }

                if (firstNode != null && secondNode != null)
                {
                    break;
                }

                foreach (var nodeChild in node._children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            if (firstNode==null || secondNode==null)
            {
                throw new ArgumentNullException();
            }
            var tempValue = firstNode.Value;
            if (firstNode.Parent == null || secondNode.Parent == null)
            {
                firstNode.Value = secondNode.Value;
                secondNode.Value = tempValue;
            }
            if (firstNode.Parent == null)
            {
                firstNode._children.Clear();
                firstNode._children.AddRange(secondNode._children);
                return;
            }

            else if (secondNode.Parent == null)
            {
                secondNode._children.Clear();
                secondNode._children.AddRange(secondNode._children);
                return;
            }
           

            var tempParent = firstNode.Parent;
            firstNode.Parent = secondNode.Parent;
            secondNode.Parent = tempParent;

            firstNode.Parent._children[firstNode.Parent._children.IndexOf(secondNode)] = firstNode;
            secondNode.Parent._children[secondNode.Parent._children.IndexOf(firstNode)] = secondNode;

           





        }

       
    }
}
