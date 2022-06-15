using _03.PriorityQueue;
using System;
using System.Collections.Generic;

namespace _3.PriorityQueues
{
    class Program
    {
        static void Main(string[] args)
        {

            PriorityQueue<int> queue = new PriorityQueue<int>();

            List<int> list = new List<int>() { 5, 8, 19, 2, 7, 190, 350 };

            foreach (var item in list)
            {
                queue.Add(item);
            }

            List<int> queuedList = new List<int>();

            while (queue.Size>0)
            {
                queuedList.Add(queue.Dequeue());
            }

            Console.WriteLine(string.Join(" ",queuedList));
        }
    }
}
