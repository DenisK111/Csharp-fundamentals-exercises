namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        private int count;
        public BinarySearchTree()
        {

        }

        public BinarySearchTree(Node<T> root)
        {
            this.CopyNode(root);
        }

        private void CopyNode(Node<T> root)
        {
            if (root != null)
            {
                this.Insert(root.Value);
                this.CopyNode(root.LeftChild);
                this.CopyNode(root.RightChild);

            }
        }

        public Node<T> Root { get; private set; }

        public int Count => count;

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

            Insert(element, Root);



        }

        private void Insert(T element, Node<T> root)
        {
            if (root == null)
            {
                Root = new Node<T>(element, null, null);
                count++;
                return;
            }

            var currElement = root;

            if (currElement.Value.CompareTo(element) == 0)
            {
                return;
            }

            if (element.CompareTo(currElement.Value) < 0)
            {
                if (currElement.LeftChild == null)
                {
                    currElement.LeftChild = new Node<T>(element, null, null);
                    count++;
                    return;
                }

                currElement = currElement.LeftChild;
                Insert(element, currElement);

            }

            if (element.CompareTo(currElement.Value) > 0)
            {
                if (currElement.RightChild == null)
                {
                    currElement.RightChild = new Node<T>(element, null, null);
                    count++;
                    return;
                }

                currElement = currElement.RightChild;
                Insert(element, currElement);

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

        public void EachInOrder(Action<T> action)
        {
            List<T> list = new List<T>();
            GetAsList(list, Root);
            list.Sort();
            foreach (var item in list)
            {
                action(item);
            }
        }

        private void GetAsList(List<T> list,Node<T> root)
        {
            if (root == null)
            {

                return;
            }

            list.Add(root.Value);
            GetAsList(list, root.LeftChild);
            GetAsList(list, root.RightChild);
            

        }

        public List<T> Range(T lower, T upper)
        {

            List<T> list = new List<T>();
            GetRange(lower, upper, list, Root);
            list.Sort();
            return list;

        }

        private void GetRange(T lower, T upper, List<T> list, Node<T> root)
        {

            if (root == null)
            {
                return;
            }

            var currElement = root;

            if (currElement.Value.CompareTo(lower) >= 0 && currElement.Value.CompareTo(upper) <= 0)
            {

                list.Add(currElement.Value);
                GetRange(lower, upper, list, currElement.LeftChild);
                GetRange(lower, upper, list, currElement.RightChild);

            }

            if (currElement.Value.CompareTo(lower) < 0)
            {

                GetRange(lower, upper, list, currElement.RightChild);
            }

            if (currElement.Value.CompareTo(upper) > 0)
            {


                GetRange(lower, upper, list, currElement.LeftChild);
            }
        }



        public void DeleteMin()
        {
            Validate();
            if (Count == 1)
            {
                Root = null;
                count--;
                return;
            }
            var currNode = Root;
            while (currNode.LeftChild.LeftChild != null)

            {
                currNode = currNode.LeftChild;
            }

            if (currNode.LeftChild.RightChild != null)
            {
                var temp = currNode.LeftChild.RightChild;
                currNode.LeftChild.RightChild = currNode.LeftChild;
                currNode.LeftChild = temp;
                currNode.LeftChild.RightChild = null;
                count--;
                return;

            }
            else
            {
                currNode.LeftChild = null;
                count--;
                return;

            }



        }

        public void DeleteMax()
        {
            Validate();
            if (Count == 1)
            {
                Root = null;
                count--;
                return;
            }
            var currNode = Root;
            while (currNode.RightChild.RightChild != null)

            {
                currNode = currNode.RightChild;
            }

            if (currNode.RightChild.LeftChild != null)
            {
                var temp = currNode.RightChild.LeftChild;
                currNode.RightChild.LeftChild = currNode.RightChild;
                currNode.RightChild = temp;
                currNode.RightChild.LeftChild = null;
                count--;
                return;

            }
            else
            {
                currNode.RightChild = null;
                count--;
                return;

            }

        }

        public int GetRank(T element)
        {
            return CountElements(element, Root);
        }

        private int CountElements(T element, Node<T> root)
        {
            var countOfElements = 0;
            if (root == null)
            {
                return countOfElements;
            }


            if (element.CompareTo(root.Value) > 0)
            {
                countOfElements++;
                countOfElements += CountElements(element, root.LeftChild) + CountElements(element, root.RightChild);
            }

            if (element.CompareTo(root.Value) <= 0)
            {
                countOfElements += CountElements(element, root.LeftChild);
            }

            return countOfElements;
        }

        private void Validate()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
