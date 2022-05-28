using System;

namespace _2.Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(6));
        }

        private static int Factorial(int n)
        {

            if (n==1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
