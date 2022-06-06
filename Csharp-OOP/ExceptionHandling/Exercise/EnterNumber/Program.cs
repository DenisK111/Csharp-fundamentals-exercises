using System;

namespace EnterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                int n = ReadNumber(1, 100);

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number! Please enter the numbers again");
                    i = -1;
                }

            }

            Console.WriteLine("Congratulations! 10 numbers entered!");
        }

        public static int ReadNumber(int start,int end)
        {

            int n = int.Parse(Console.ReadLine());

            if (n<start || n>end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return n;
        }
    }
}
