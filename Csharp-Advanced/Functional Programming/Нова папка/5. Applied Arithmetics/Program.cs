using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        /* Create a program that executes some mathematical operations on a given collection. On the first line, you are given a list of numbers. On the next lines you are passed different commands that you need to apply to all the numbers in the list:
•	"add" -> add 1 to each number
•	"multiply" -> multiply each number by 2
•	"subtract" -> subtract 1 from each number
•	"print" -> print the collection
•	"end" -> ends the input 
*/
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                Func<int, int> add = x => x + 1;
                Func<int, int> subtract = x => x - 1;
                Func<int, int> multiply = x => x * 2;
                Action<int> print = x => Console.Write($"{x} ");

                switch (command)
                {
                    case "add": input = input.Select(add).ToList(); ; break;
                    case "multiply": input = input.Select(multiply).ToList(); break;
                    case "subtract": input = input.Select(subtract).ToList(); break;
                    case "print": input.ForEach(print);
                        Console.WriteLine(); break;
                    default:break;
                }
            }


        }
    }
}
