using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {

        /* Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), an integer S representing the number of elements to dequeue (remove) from the queue, and finally an integer X, an element that you should look for in the queue. If it is, print true on the console. If it’s not printed the smallest element is currently present in the queue. If there are no elements in the sequence, print 0 on the console.*/

        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToQueue = parameters[0];
            int elementsToDequeue = parameters[1];
            int elementToLookFor = parameters[2];

            Queue<int> intQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < elementsToDequeue; i++)
            {
                intQueue.Dequeue();
            }

            if (intQueue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int smallestElement = int.MaxValue;

            foreach (var item in intQueue)
            {
                if (item == elementToLookFor)
                {
                    Console.WriteLine("true");
                    return;
                }

                else if (item<smallestElement)
                {
                    smallestElement = item;
                }
            }

            Console.WriteLine(smallestElement);
        }
    }
}
