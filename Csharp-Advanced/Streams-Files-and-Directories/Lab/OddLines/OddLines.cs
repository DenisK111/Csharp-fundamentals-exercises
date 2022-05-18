
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            
            
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {


                    for (int i = 0; i < inputFilePath.Length; i++)
                    {
                        var line = reader.ReadLine();
                        if (i % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}

