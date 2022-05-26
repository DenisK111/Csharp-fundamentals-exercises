using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            Func<int, int, int> Comperator = (x, y) =>
              {
                  if (x % 2 == 0 & y % 2 != 0)
                  {
                      return -1;
                  }

                  else if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
                  {
                      return x < y ? -1 : x > y ? 1 : 0;
                  }

                  else
                  {
                      return 1;
                  }

              };
            Array.Sort(input, (x,y) => Comperator(x,y));

            Console.WriteLine(String.Join(" ",input));
        }

        

    }

  

}
