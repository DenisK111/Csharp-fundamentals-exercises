namespace EvenLines
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
                List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {

                var line = reader.ReadLine();
                int lineNum = 0;
                while (line != null)
                {
                    if (lineNum%2 == 0)
                    {
                       line = ReplaceSymbols(line);
                        line = ReverseWords(line);
                        lines.Add(line);
                    }
                    lineNum++;
                    line = reader.ReadLine();
                }

            }


            return String.Join("\n", lines);

        }
        private static string ReverseWords(string replacedSymbols)
        {
            return String.Join(" ", replacedSymbols.Split().Reverse().ToArray());
        }

        private static string ReplaceSymbols(string line)
        {
            Regex regex = new Regex(@"[\-,\.\!\?]");
            return regex.Replace(line, "@");
        }
    }

}
