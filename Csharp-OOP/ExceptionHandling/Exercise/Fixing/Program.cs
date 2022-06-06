using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekday = new string[5];


            weekday[0] = "Sunday";
            weekday[1] = "Monday";
            weekday[2] = "Tuesday";
            weekday[3] = "Wednesday";
            weekday[4] = "Thursday";

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                Console.WriteLine(weekday[i].ToString());

                }
                catch (IndexOutOfRangeException)
                {

                    Console.WriteLine("Problem Fixed, no more exceptions!");
                }
            }
        }
    }
}
