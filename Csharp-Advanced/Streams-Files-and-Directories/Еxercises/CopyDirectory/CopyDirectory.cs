namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {

            Directory.CreateDirectory(outputPath);




            DirectoryInfo filesInput = new DirectoryInfo(inputPath);
            DirectoryInfo filesOutPut = new DirectoryInfo(outputPath);
           
            var files = filesInput.GetFiles();

            if (filesOutPut.Exists)
            {
                filesOutPut.Delete(true);
                
            }

            
            filesOutPut.Create();
            foreach (var file in files)
            {
                file.CopyTo(@$"{outputPath}\\{file.Name}");
            }
            


           
            
        }
    }
}
