using System;
using System.Collections.Generic;

namespace Cinema
{
    internal class Program
    {

        static string[] elements;
        static string[] permutations;
        static bool[] used;
        static Dictionary<int, string> keyValuePairs;
        static void Main(string[] args)
        {

            elements = Console.ReadLine().Split(", ");
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            keyValuePairs = new Dictionary<int, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "generate")
                {
                    break;
                }

                string[] kvp = input.Split(" - ");
                keyValuePairs.Add(int.Parse(kvp[1]) - 1, kvp[0]);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index == permutations.Length)
            {
                bool match = true;
                foreach (var kvp in keyValuePairs)
                {
                    if (kvp.Value != permutations[kvp.Key])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    Console.WriteLine(String.Join(" ", permutations));
                }

                return;
            }



            for (int i = 0; i < permutations.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permute(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
