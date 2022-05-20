using System;
using System.Linq;

namespace _3._Count_UpperCase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> upperCase = x => char.IsUpper(x[0]);

            Console.WriteLine(String.Join("\n",words.Where(upperCase)));



        }
    }
}
