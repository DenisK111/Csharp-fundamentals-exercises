using System;
using System.Linq;

namespace PermutationsWithoutRepetitions
{
    internal class Program
    {
        static string[] elements;
        static string[] permutations;
        static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutations = new string [elements.Length];
            used = new bool[permutations.Length];
                       
            Permute(0);
                
       }

        private static void Permute(int index)
        {
            if (index == permutations.Length)
            {
                Console.WriteLine(String.Join(" ",permutations));
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
