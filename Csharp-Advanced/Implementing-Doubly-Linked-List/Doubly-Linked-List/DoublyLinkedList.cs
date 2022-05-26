using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Linked_List
{
    class DoublyLinkedList<T> : IEnumerable<Node<T>>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public Node<T> PreviousHead { get; set; }
        public Node<T> PreviousTail { get; set; }

        public int Count { get; set; } = 0;
        public void AddFirst(Node<T> node)
        {

            Count++;
            if (CheckIfEmpty())
            {
                Head = node;
                Tail = node;
                return;
            }

            PreviousHead = Head;
            Head = node;
            node.Next = PreviousHead;
            node.Previous = null;
            PreviousHead.Previous = Head;

        }

        public void AddLast(Node<T> node)
        {

            Count++;
            if (CheckIfEmpty())
            {
                Head = node;
                Tail = node;
                return;
            }

            PreviousTail = Tail;
            Tail = node;
            node.Next = null;
            node.Previous = PreviousTail;
            PreviousTail.Next = Tail;

        }

        public Node<T> RemoveLast()
        {
            if (CheckIfEmpty())
            {
                return null;
            }
            Count--;

            var removed = Tail;
            Tail = PreviousTail;
            Tail.Next = null;
            Tail.Previous = PreviousTail.Previous;
            PreviousTail = Tail.Previous;
            PreviousTail.Next = Tail;
            return removed;

        }

        public Node<T> RemoveFirst()
        {
            if (CheckIfEmpty())
            {
                return null;
            }
            Count--;
            var removed = Head;
            Head = PreviousHead;
            Head.Previous = null;
            Head.Next = PreviousHead.Next;
            PreviousHead = Head.Next;
            PreviousHead.Previous = Head; // 1 2 3 4
            return removed;

        }

        //public void ForEach(Action<Node<T>> action)
        //{
        //    var currentNode = Head;
        //    while (currentNode!= null)
        //    {
        //        action(currentNode);
        //        currentNode = currentNode.Next;
        //    }

        //}

        public Node<T>[] ToArray()
        {
            var array = new Node<T>[Count];
            var currentNode = Head;
            int count = 0;
            while (currentNode != null)
            {
                array[count] = currentNode;
                currentNode = currentNode.Next;
                count++;
            }

            return array;
        }

        private bool CheckIfEmpty()
        {

            if (this.Head == null)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            var currentNode = Head;
            for (int i = 0; i < this.Count; i++)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
