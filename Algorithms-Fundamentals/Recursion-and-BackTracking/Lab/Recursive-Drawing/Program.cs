namespace Recursive_Drawing
{
    using System;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            //char symbol = '#';
            //    char symbol2 = '*';

           // StringBuilder sb = new StringBuilder();

           // Draw1stHalf(symbol2, n, sb);
           // Draw2ndHalf(symbol, 1,n, sb);

            DrawAtOnce(n);

            
        }

        private static void Draw1stHalf(char symbol, int n,StringBuilder sb)
        {

            if (n==0)
            {
                return;
            }

            sb.AppendLine(new string(symbol, n));
            Draw1stHalf(symbol, n - 1, sb);

            return;
        }

        private static void Draw2ndHalf(char symbol, int start, int n, StringBuilder sb)
        {
            if (start > n)
            {

                return;
            }

            sb.AppendLine(new string(symbol, start));
            Draw2ndHalf(symbol, start+1,n, sb);

            return;

        }

        private static void DrawAtOnce(int n)
        {
            if (n==0)
            {
                return;
            }
            Console.WriteLine(new String('*',n));
            DrawAtOnce(n - 1);
            Console.WriteLine(new String('#', n));
            return;
        }


    }
}