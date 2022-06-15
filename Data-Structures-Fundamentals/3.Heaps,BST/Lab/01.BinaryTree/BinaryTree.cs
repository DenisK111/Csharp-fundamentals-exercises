namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public object AsIndentedPreOrder()
        {
            throw new NotImplementedException();
        }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{new string(' ', indent)}{this.Value}");

            if (this.LeftChild != null)
            {
                sb.AppendLine(this.LeftChild.AsIndentedPreOrder(indent + 2));
            }

            if (this.RightChild != null)
            {
                sb.AppendLine(this.RightChild.AsIndentedPreOrder(indent + 2));
            }

            return sb.ToString().TrimEnd();

        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();


            if (this.LeftChild != null)
            {
                list.AddRange(this.LeftChild.InOrder());
            }

            list.Add(this);

            if (this.RightChild != null)
            {
                list.AddRange(this.RightChild.InOrder());
            }

            return list;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();


            if (this.LeftChild != null)
            {
                list.AddRange(this.LeftChild.PostOrder());
            }


            if (this.RightChild != null)
            {
                list.AddRange(this.RightChild.PostOrder());
            }

            list.Add(this);
            return list;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            list.Add(this);

            if (this.LeftChild != null)
            {
                list.AddRange(this.LeftChild.PreOrder());
            }


            if (this.RightChild != null)
            {
                list.AddRange(this.RightChild.PreOrder());
            }

            return list;
        }

        public void ForEachInOrder(Action<T> action)
        {
            var list = this.PreOrder();


            foreach (var item in list.OrderBy(x => x.Value))
            {
                action(item.Value);
            }
        }
    }
}
