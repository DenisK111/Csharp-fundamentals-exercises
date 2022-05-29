using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new List<string> { "1", "2", "3" });
            Console.WriteLine(stack.IsEmpty());
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack.IsEmpty());
            
        }
    }
}
