namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            var currElement = Root;

            while (true)
            {


                if (element.CompareTo(currElement.Value) == 0)
                {
                    return true;
                }

                if (element.CompareTo(currElement.Value) < 0)
                {
                    if (currElement.LeftChild == null)
                    {
                        return false;
                    }

                    currElement = currElement.LeftChild;
                }

                if (element.CompareTo(currElement.Value) > 0)
                {
                    if (currElement.RightChild == null)
                    {
                        return false;
                    }

                    currElement = currElement.RightChild;
                }
            }
        }

        public void Insert(T element)
        {
            if (Root == null)
            {
                Root = new Node<T>(element, null, null);
                return;
            }

            var currElement = Root;
            while (true)
            {


                if (element.CompareTo(currElement.Value) == 0)
                {
                    return;
                }

                if (element.CompareTo(currElement.Value) < 0)
                {
                    if (currElement.LeftChild == null)
                    {
                        currElement.LeftChild = new Node<T>(element, null, null);
                        return;
                    }

                    currElement = currElement.LeftChild;
                }

                if (element.CompareTo(currElement.Value) > 0)
                {
                    if (currElement.RightChild == null)
                    {
                        currElement.RightChild = new Node<T>(element, null, null);
                        return;
                    }

                    currElement = currElement.RightChild;
                }
            }


        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var currElement = Root;

            while (true)
            {


                if (element.CompareTo(currElement.Value) == 0)
                {
                    return new BinarySearchTree<T>(currElement);
                }

                if (element.CompareTo(currElement.Value) < 0)
                {
                    if (currElement.LeftChild == null)
                    {
                        return null;
                    }

                    currElement = currElement.LeftChild;
                }

                if (element.CompareTo(currElement.Value) > 0)
                {
                    if (currElement.RightChild == null)
                    {
                        return null;
                    }

                    currElement = currElement.RightChild;
                }
            }
        }
    }
}
