namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                sum += file.Length;
            }

            
            
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine($"{sum / 1024} KB");
                }
           

        }
    }
}
