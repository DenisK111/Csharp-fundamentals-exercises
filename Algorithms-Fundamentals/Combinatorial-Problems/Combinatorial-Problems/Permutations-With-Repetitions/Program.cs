using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsWithRepetitions
{
    internal class Program
    {
        static string[] elements;
        static string[] permutations;
        static bool[] used;
        private static HashSet<string> alreadyUsed;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[permutations.Length];
            alreadyUsed = new HashSet<string>();

           // PermuteSlow(0);
            PermuteFast(0);

        }

        private static void PermuteFast(int index)
        {
            if (index>=elements.Length)
            {
                Console.WriteLine(String.Join(" ",elements));
                return;
            }

            PermuteFast(index + 1);

            var alreadyExists = new HashSet<string> { elements[index] };

            for (int i = index+1; i < elements.Length; i++)
            {
                if (!alreadyExists.Contains(elements[i]))
                {
                    
                    Swap(index, i);
                    PermuteFast(index + 1);
                    Swap(index, i);
                    alreadyExists.Add(elements[i]);
                    
                }
                    
                
                
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }

        private static void PermuteSlow(int index)
        {
            if (index >= permutations.Length && !alreadyUsed.Contains(String.Join("", permutations)))
            {
                alreadyUsed.Add(String.Join("", permutations));
                Console.WriteLine(String.Join(" ", permutations));
                return;
            }
            

            

            for (int i = 0; i < permutations.Length; i++)
            {
                           
                    if (!used[i])
                    {
                     
                        used[i] = true;
                        permutations[index] = elements[i];
                        PermuteSlow(index + 1);
                        used[i] = false;
                       

                    }

            }
        }
    }
}
