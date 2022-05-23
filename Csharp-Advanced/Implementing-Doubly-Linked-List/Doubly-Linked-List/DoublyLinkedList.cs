using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_Linked_List
{
    class DoublyLinkedList
    {

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public Node PreviousHead { get; set; }
        public Node PreviousTail { get; set; }

        public int Count { get; set; } = 0;
        public void AddHead(Node node)
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

        public void AddTail(Node node)
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

        public Node RemoveTail()
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

        public Node RemoveHead()
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

        public void ForEach(Action<Node> action)
        {
            var currentNode = Head;
            while (currentNode!= null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }

        }

        public Node[] ToArray()
        {
            var array = new Node[Count];
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
    }
}
