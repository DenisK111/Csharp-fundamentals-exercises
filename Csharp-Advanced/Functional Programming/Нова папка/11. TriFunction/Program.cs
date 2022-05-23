using System;
using System.Collections.Generic;
using System.Linq;


namespace _11._TriFunction
{
    class Program
    {
        /* Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line. Use a function that accepts another function as one of its parameters. Start by building a regular function to hold the basic logic of the program. Something along the lines of Func<string, int, bool>. Afterward, create your main function which should accept the first function as one of its parameters.*/

        static void Main(string[] args)
        {
            Func<string, int, bool> checker = (x, y) => x.Sum(x=>x) >= y;
            Action<Func<string, int, bool>, int, List<string>> printResult = (checker, n, input) => Console.WriteLine(input.FirstOrDefault(x => checker(x, n)));
            printResult(checker, int.Parse(Console.ReadLine()), Console.ReadLine().Split().ToList());

        }
    }
}
