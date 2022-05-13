using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> intStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());


            while (true)
            {

                string[] command = Console.ReadLine().ToLower().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "add")
                {
                    intStack.Push(int.Parse(command[1]));
                    intStack.Push(int.Parse(command[2]));
                }

                else
                {
                    if (intStack.Count > int.Parse(command[1]))
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            intStack.Pop();
                        }
                    }
                    
                }


            }

            int sum = 0;

            while (intStack.Count>0)
            {
                sum += intStack.Pop();
            }

            Console.WriteLine("Sum: {0}",sum);



        }
    }
}
