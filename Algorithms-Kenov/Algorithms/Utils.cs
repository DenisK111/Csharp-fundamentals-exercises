using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class Utils
    {
        public static void Print(char[,] dArray)
        {
            for (int row = 0; row < dArray.GetLength(0); row++)
            {
                for (int col = 0; col < dArray.GetLength(1); col++)
                    Console.Write(dArray[row, col]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void ForEach<T>(this IEnumerable<T> source,Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        public static T ReadT<T>(Func<string,T> func) => func(Console.ReadLine()!);
        public static int ReadInt() => ReadT(int.Parse);
        public static int[] ReadIntArray() => Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        public static string EnumerableAsString<T>(IEnumerable<T> source, string separator = " ") => string.Join(separator, source);
        public static void Print(object item) => Console.WriteLine(item);
        public static void PrintEnumerable<T>(IEnumerable<T> source, string separator = " ") => Print(EnumerableAsString(source,separator));
    }
}
