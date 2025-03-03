﻿using System;

namespace NChooseKcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Binom(n, k));
        }

        private static int Binom(int row, int col)
        {
            if (row<=1)
            {
                return 1;
            }

            if (col==0 || col == row)
            {
                return 1;
            }

            return Binom(row - 1, col) + Binom(row - 1, col - 1);
        }
    }
}
