using System;

namespace Implementing_Stack_and_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.ForEach(Console.WriteLine);

            Console.WriteLine(stack.Pop() == 3);
            Console.WriteLine(stack.Peek() == 2);


        }
    }
}
