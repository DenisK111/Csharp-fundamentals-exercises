using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Words
    {
        public static void Run()
        {
            string input = Console.ReadLine()!;
            char[] elements = input.ToCharArray();

            if (elements.Length == elements.Distinct().Count())
            {
                long result = Enumerable.Range(1,elements.Length).Aggregate(1, (acc,el) => acc * el);
                Console.WriteLine(result);
                return;
            }

            int count = 0;
            var permutations = new HashSet<string>();
            HeapPermutation(elements, elements.Length, elements.Length);
            Console.WriteLine(count);
            

            void HeapPermutation(char[] a, int size, int n)
                
            {
                // if size becomes 1 then prints the obtained
                // permutation
                if (size == 1)
                {
                    for (int i = 1; i < a.Length; i++)
                    {
                        if (a[i] == a[i - 1]) return;
                    }
                    var perm = new string(a);
                    if (!permutations.Contains(perm))
                    {
                        permutations.Add(new string(a));
                        count++;
                    }
                }
                    

                for (int i = 0; i < size; i++)
                {
                   
                    HeapPermutation(a, size - 1, n);

                    // if size is odd, swap 0th i.e (first) and
                    // (size-1)th i.e (last) element
                    if (size % 2 == 1)
                    {
                        if (a[0] == a[size - 1]) continue;
                        char temp = a[0];
                        a[0] = a[size - 1];
                        a[size - 1] = temp;
                    }

                    // If size is even, swap ith and
                    // (size-1)th i.e (last) element
                    else
                    {
                        if (a[i] == a[size - 1]) continue;
                        char temp = a[i];
                        a[i] = a[size - 1];
                        a[size - 1] = temp;
                    }
                }
            }

        }
    }
}
