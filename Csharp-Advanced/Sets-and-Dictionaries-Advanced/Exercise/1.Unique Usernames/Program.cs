using System;
using System.Collections.Generic;

namespace _1.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = new HashSet<string>();

            for (int i = 0; i <n; i++)
            {
                string command = Console.ReadLine();

                names.Add(command);
            }

            Console.WriteLine(String.Join("\n",names));


        }
    }
}
