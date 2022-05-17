using System;
using System.Collections.Generic;

namespace _6.Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> setOfNames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                setOfNames.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join("\n",setOfNames));
        }
    }
}
