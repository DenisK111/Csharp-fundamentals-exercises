using System;
using System.Collections.Generic;

namespace Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            Node<string> node = new Node<string>("5");
            list.AddFirst(node);
            list.AddFirst(new Node<string>("3.2"));
            list.AddFirst(new Node<string>("2.2"));
            list.AddLast(new Node<string>("10.2"));
            list.AddLast(new Node<string>("11.2"));
            list.AddLast(new Node<string>("12.1"));
            list.RemoveLast();
            list.RemoveLast();
            
            list.AddLast(new Node<string>("10"));
            list.RemoveFirst();
            


            var currentNode = list.Head;
             while (currentNode != null)
           {
             Console.WriteLine(currentNode.Value);
           currentNode = currentNode.Next;
           }
           // list.ForEach(x => Console.WriteLine(x.Value));
            var nodeList = list.ToArray();
            Console.WriteLine();

         

            foreach (var item in list )
            {
                Console.WriteLine(item.Value);
            }
            
            
        }
    }
}
