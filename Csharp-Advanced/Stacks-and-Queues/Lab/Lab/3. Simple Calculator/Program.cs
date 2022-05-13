using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stack<string> expression = new Stack<string>(Console.ReadLine().Split().ToArray().Reverse());

            int result = int.Parse(expression.Pop()); // 2 + 5 + 10 - 2 - 1

            
            while (expression.Count>0)
            {
                string symbol = expression.Pop();

                if (symbol=="+")
                {
                    result += int.Parse(expression.Pop());
                }

                else if (symbol == "-")
                {
                    result -= int.Parse(expression.Pop());
                }
                                
            }

            Console.WriteLine(result);


        }
    }
}
