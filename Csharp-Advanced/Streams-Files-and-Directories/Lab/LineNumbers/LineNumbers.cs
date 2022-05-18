namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {

                    var line = reader.ReadLine();
                    var i = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{i++}. {line}");
                        
                        line = reader.ReadLine();
                    }
                    
                }
            }
        }
    }
}
