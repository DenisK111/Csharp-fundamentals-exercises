using System;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = 10;

            Test(num, out num);

            Console.WriteLine(num);
        }

        public static void Test(int num, out int number)
        {
            number = 0;
            number += 20;

        }
    }
}
