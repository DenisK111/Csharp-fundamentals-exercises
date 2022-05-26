using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Lake<int> lake = new Lake<int>(input);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
