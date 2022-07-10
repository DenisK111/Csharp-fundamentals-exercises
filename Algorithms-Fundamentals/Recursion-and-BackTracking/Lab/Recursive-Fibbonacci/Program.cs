namespace Recursive_Fibbonacci
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()!);


            Dictionary<int, int> savedValues = new Dictionary<int, int>();
            Dictionary<int, int> savedValues2 = new Dictionary<int, int>();
            savedValues.Add(0, 1);
            savedValues.Add(1, 1);
            savedValues2.Add(0, 1);
            savedValues2.Add(1, 1);
            int op1 = 0;
            int op2 = 0;
            Stopwatch watch = new Stopwatch();
           watch.Start();
           Console.WriteLine(Fibbonacci(n,savedValues, ref op1));
           watch.Stop();
           Console.WriteLine(watch.ElapsedMilliseconds);
           watch.Reset();
           Console.WriteLine(op1);
            watch.Start();
            Console.WriteLine(FibonacciSlow(n,savedValues2, ref op2));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
           Console.WriteLine(op2);
        }

        private static int Fibbonacci(int n,Dictionary<int,int> savedValues,ref int op)
        {
            if (savedValues.ContainsKey(n))
            {
                return savedValues[n];
            }
            op++;
            savedValues.Add(n, Fibbonacci(n - 1, savedValues, ref op) + Fibbonacci(n - 2, savedValues, ref op));

            return savedValues[n];


        }

        private static int FibonacciSlow(int n, Dictionary<int, int> savedValues, ref int op)
        {
            if (savedValues.ContainsKey(n))
            {
                return savedValues[n];
            }
            op++;
            return FibonacciSlow(n - 1, savedValues, ref op) + FibonacciSlow(n - 2, savedValues, ref op);

            

        }
    }
}