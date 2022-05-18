namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader1 = new StreamReader(firstInputFilePath))
                {
                    using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                    {
                        var line1 = reader1.ReadLine();
                        var line2 = reader2.ReadLine();
                        while (line1!= null || line2 != null)
                        {
                            if (line1 != null)
                            {
                            writer.WriteLine(line1);

                            }

                            if (line2!=null)
                            {
                            writer.WriteLine(line2);

                            }


                            line1 = reader1.ReadLine();
                            line2 = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
