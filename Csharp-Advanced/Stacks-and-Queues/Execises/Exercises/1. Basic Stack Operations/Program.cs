using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        /* Play around with a stack. You will be given an integer N representing the number of elements to push into the stack, an integer S representing the number of elements to pop from the stack, and finally an integer X, an element that you should look for in the stack. If it’s found, print "true" on the console. If it isn't, print the smallest element currently present in the stack. If there are no elements in the sequence, print 0 on the console.
Input
•	On the first line, you will be given N, S, and X, separated by a single space
•	On the next line, you will be given N number of integers
Output
•	On a single line print either true if X is present in the stack, otherwise print the smallest element in the stack. If the stack is empty, print 0
*/
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToPush = parameters[0];
            int elementsToPop = parameters[1];
            int elementToLookFor = parameters[2];

            Stack<int> intStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < elementsToPop; i++)
            {
                intStack.Pop();
            }

            if (intStack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (intStack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(intStack.Min());
            }

        }
    }
}
