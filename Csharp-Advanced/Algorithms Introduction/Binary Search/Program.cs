using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = 100;
            int[] input = Enumerable.Range(101, range).ToArray();

            int target = 150;
            int baseNum = range;
            int current =baseNum/2 -1;
            int operations = 0;
            while (true)
            {
              
                operations++;
                
                
                if (input[current] == target)
                {
                    break;
                }

                if (input[current]>target)
                {
                    baseNum = current;
                    current = baseNum / 2;
                }

                if (input[current]<target)
                {
                    current = (int)Math.Round((baseNum + current) / (2 * 1.0));
                }


            }

            Console.WriteLine(input[current] + " " + operations);



                
        }
    }
}
