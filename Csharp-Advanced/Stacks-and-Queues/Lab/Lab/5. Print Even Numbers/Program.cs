using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> evenNums = new List<int>();
            while (numbers.Count>0)
            {
                int num = numbers.Dequeue();
                
                if (num % 2 == 0)
                {
                    evenNums.Add(num);
                }
            }
            Console.WriteLine(String.Join(", ",evenNums));

        }
    }
}
