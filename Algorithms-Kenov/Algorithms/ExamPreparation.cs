using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ExamPreparation
    {
        public static void ShootingRange()
        {

            int[] input = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine()!);
            List<int[]> permutations = new ();
            GetPer(input, 0, input.Length - 1);
            var results = new HashSet<string>();
            permutations.ForEach(p => Accumulate(p,target,1,0));       
            
            if(results.Count == 0)
            {
                Console.WriteLine($"Score of {target} cannot be achieved.");
            }

            void GetPer(int[] input, int a, int b)
            {
                if (a == b)
                {
                    permutations.Add(input.ToArray());
                }
                else
                {
                    for (int i = a; i<= b; i++) 
                    {

                        Swap(a, i);
                        GetPer(input, a + 1, b);
                        Swap(a, i);
                    }
                }
            }


            void Swap(int a, int b) {

                if (a == b || input[a] == input[b]) return;
                var temp = input[a];
                input[a] = input[b];
                input[b] = temp;
            }

            void Accumulate(int[] input, int target, int depth, int currentValue)
            {
                if (currentValue == target)
                {
                    var result = string.Join(" ", input.Take(depth - 1));
                    if (!results.Contains(result))
                    {
                        results.Add(result);
                        Console.WriteLine(result);
                    }                   
                    return;
                }

                if (depth > input.Length) return;

                Accumulate(input,target,depth + 1, currentValue + input[depth - 1] * depth);

            }
        }
    }
}
