using System;
using System.Collections.Generic;


namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> input = new Stack<char>(Console.ReadLine().ToCharArray());

            while (input.Count>0)
            {
                Console.Write(input.Pop());
            }
        }
    }
}
