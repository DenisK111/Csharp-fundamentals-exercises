using System;

namespace Variations_Without_Repetitions
{
    internal class Program
    {
        static string[] elements;
        static string[] permutations;
        static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());
            permutations = new string[elements.Length];
            used = new bool[permutations.Length];

            Variate(0,k);

        }

        private static void Variate(int index,int length)
        {
            if (index == length)
            {
                Console.WriteLine(String.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < permutations.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Variate(index+1,length);
                    used[i] = false;
                }
            }
        }
    }
}
