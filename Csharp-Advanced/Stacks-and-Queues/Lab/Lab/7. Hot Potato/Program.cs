using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        /* Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with the first kid. Every nth toss the child left with the potato leaves the game. When a kid leaves the game, it passes the potato along. This continues until there is only one kid left.
Create a program that simulates the game of Hot Potato.  Print every kid that is removed from the circle. In the end, print the kid that is left last.
*/
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Queue<string> kids = new Queue<string>(input);

            int n = int.Parse(Console.ReadLine());

            int count = 1;
            while (kids.Count!=1)
            {
                string kid = kids.Dequeue();
                if (count!=n)
                {
                    kids.Enqueue(kid);
                    count++;
                }

                else
                {
                    count = 1;
                    Console.WriteLine($"Removed {kid}");

                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");


        }
    }
}
