using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ", 2);


            MyStack<string> stack = new MyStack<string>(command[1].Split(", "));

            while (true)
            {
                command = Console.ReadLine().Split(" ", 2);
                if (command[0] == "END")
                {
                    break;
                }

                if (command[0] == "Pop")
                {
                    stack.Pop();
                }

                else
                {
                    stack.Push(command[1].Split(", "));
                }


            }

            foreach (var item in stack)
            {
                Console.WriteLine(item.Value);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item.Value);
            }


        }

    }
}
