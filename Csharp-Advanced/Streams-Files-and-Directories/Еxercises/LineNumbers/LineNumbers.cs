namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {

            var lines = File.ReadAllLines(inputFilePath);
            string[] modifiedLines = new string[lines.Length];
            int count = 0;
            Regex punctuation = new Regex(@"[^A-Za-z ]");
            Regex letters = new Regex(@"[A-Za-z]");
            foreach (var item in lines)
            {
                modifiedLines[count] = $"Line {count + 1}: {item} ({letters.Matches(item).Count})({punctuation.Matches(item).Count})";
                    count++;
            }

            File.WriteAllLines(outputFilePath, modifiedLines);

        }
    }
}
