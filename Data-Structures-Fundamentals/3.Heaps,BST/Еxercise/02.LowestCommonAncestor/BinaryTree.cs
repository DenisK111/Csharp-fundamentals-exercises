namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            if (LeftChild!=null)
            {
            this.LeftChild.Parent = this;

            }

            if (RightChild != null)
            {

            this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var startRange = Search(first);
            var endRange = Search(second);
          
            var list1 = new List<T>();
            var list2 = new List<T>();
            LowestCommonAncestor(startRange, endRange, list1, list2);



            return list1.Intersect(list2).ToArray()[0];

        }

        private BinaryTree<T> Search(T element)
        {
            var currElement = this;

            while (true)
            {


                if (element.CompareTo(currElement.Value) == 0)
                {
                    return currElement;
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



        private void LowestCommonAncestor(BinaryTree<T> first, BinaryTree<T> second, List<T> list1, List<T> list2)
        {
            var firstNode = first;
            while (firstNode!= null)
            {
                list1.Add(firstNode.Value);
                firstNode = firstNode.Parent;
            }

            var secondNode = second;

            while (secondNode != null)
            {
                list2.Add(secondNode.Value);
                secondNode = secondNode.Parent;
            }


        }
    }
}
