namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(textFilePath))
                {
                    string words = File.ReadAllText(wordsFilePath);
                    string[] wordArray = words.Split();
                    Dictionary<string, int> wordsOccurrences = new Dictionary<string, int>();
                    foreach (var item in wordArray)
                    {
                        wordsOccurrences.Add(item, 0);
                    }
                    var text = reader.ReadToEnd();
                    foreach (var item in wordArray)
                    {
                        MatchCollection matches = Regex.Matches(text, @$"\b{item}\b",RegexOptions.IgnoreCase);
                        wordsOccurrences[item] = matches.Count;
                    }

                    foreach (var item in wordsOccurrences.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
