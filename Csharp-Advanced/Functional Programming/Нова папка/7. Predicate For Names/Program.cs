using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Predicate_For_Names
{
    class Program
    {
        /* Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.*/ 

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> validNames = (x,y) => x.Length <= y;
            Console.WriteLine(String.Join("\n",names.Where(x => validNames(x,n))));

        }
    }
}
