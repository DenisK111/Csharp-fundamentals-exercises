namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public bool Color { get; set; }
        }

        public Node root;

        private RedBlackTree(Node node)
        {
            this.PreOrderCopy(node);
        }


        public RedBlackTree()
        {

        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public RedBlackTree<T> Search(T element)
        {
            Node current = this.FindElement(element);
            return new RedBlackTree<T>(current);
        }

        private Node FindElement(T element)
        {
            var current = this.root;

            while (current != null)
            {
                if (IsLesser(element, current.Value))
                {
                    current = current.Left;
                }
                else if (IsLesser(current.Value, element))
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
            this.root.Color = Black;
        }

        public void Delete(T element)
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.Delete(root, element);

            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

       

        public void DeleteMax()
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.DeleteMax(this.root);
            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        private int Count(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + this.Count(root.Left) + this.Count(root.Right);
        }

        private void PreOrderCopy(Node node)
        {
            if (node is null) return;

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);

        }

        private Node Insert(Node node, T element)
        {
            if (node is null) return new Node(element);

            if (IsLesser(element, node.Value))
            {
                node.Left = this.Insert(node.Left, element);
            }

            else
            {
                node.Right = this.Insert(node.Right, element);
            }

            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node);
            }

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }

        private Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
            {
                node = RotateRight(node);
            }

            if (node.Right == null)
            {
                return null;
            }

            if (!IsRed(node.Right) && IsRed(node.Right.Left))
            {
                node = MoveRedRight(node);
            }

            node.Right = DeleteMax(node.Right);

            return FixUp(node);
        }

        private Node Delete(Node node, T element)
        {
            if (IsLesser(element, node.Value))
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = MoveRedLeft(node);
                }
                node.Left = Delete(node.Left, element);
            }

            else
            {
                if (IsRed(node.Left))
                {
                    node = RotateRight(node);
                }

                if (AreEqual(element, node.Value) && node.Right == null)
                {
                    return null;
                }

                if (!IsRed(node.Right) && IsRed(node.Right.Left))
                {
                    node = MoveRedRight(node);
                }

                if (AreEqual(element, node.Value))
                {
                    node.Value = FindMinimalValueInSubtree(node.Right);
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, element);

                }
            }

            return FixUp(node);
        }

        private T FindMinimalValueInSubtree(Node node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return FindMinimalValueInSubtree(node.Left);
        }

        public void DeleteMin()
        {
            if (this.root == null) throw new InvalidOperationException();

            this.root = this.DeleteMin(this.root);
            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

        // HELPER METHODS

        private bool IsLesser(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private bool AreEqual(T a, T b)
        {
            return a.CompareTo(b) == 0;
        }

        //ROTATIONS
        private Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }

        private Node MoveRedLeft(Node node)
        {
            FlipColors(node);

            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                FlipColors(node);
            }

            return node;
        }

        private Node MoveRedRight(Node node)
        {
            FlipColors(node);

            if (IsRed(node.Left.Left))
            {
                node = RotateRight(node);
                FlipColors(node);
            }

            return node;
        }

        private void FlipColors(Node node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Red;
        }

        private Node RotateLeft(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = node.Color;
            temp.Left.Color = Red;
            return temp;

        }

        private Node RotateRight(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = node.Color;
            temp.Right.Color = Red;
            return temp;
        }
    }
}