using System;
using System.Collections.Generic;

namespace Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            Node node = new Node(5);
            list.AddHead(node);
            list.AddHead(new Node(3));
            list.AddHead(new Node(2));
            list.AddTail(new Node(10));
            list.AddTail(new Node(11));
            list.AddTail(new Node(12));
            list.RemoveTail();
            list.RemoveTail();
            
            list.AddTail(new Node(10));
            list.RemoveHead();
            


            var currentNode = list.Head;
            // while (currentNode != null)
            //{
            //  Console.WriteLine(currentNode.Value);
            //currentNode = currentNode.Next;
            //}
            list.ForEach(x => Console.WriteLine(x.Value));
            var nodeList = list.ToArray();
            Console.WriteLine();

            foreach (var item in nodeList)
            {
                Console.WriteLine(item.Value);
            }

            
            
        }
    }
}
