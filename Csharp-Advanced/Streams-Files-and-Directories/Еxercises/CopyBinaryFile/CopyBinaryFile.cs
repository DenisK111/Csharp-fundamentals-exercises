using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {

            using (FileStream reader = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[10];
                    int count = buffer.Length;
                    while (count == buffer.Length)
                    {
                    count = reader.Read(buffer, 0, buffer.Length);
                    writer.Write(buffer, 0, buffer.Length);
                        buffer = new byte[10];
                    }



                }
            }
        }
    }
}
