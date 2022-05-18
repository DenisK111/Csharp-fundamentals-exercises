namespace ExtractBytes
{
    using System;
    using System.IO;
    using System.Linq;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream filestream = new FileStream(outputPath,FileMode.Create,FileAccess.Write))
            {
                using (FileStream reader = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream pngReader = new FileStream(binaryFilePath,FileMode.Open,FileAccess.Read))
                    {
                        int count = 20;
                        
                        byte[] buffer = new byte[count];
                        int bytesRead = count;
                        byte[] textBuffer = new byte[reader.Length];
                        reader.Read(textBuffer, 0, (int)reader.Length);
                        while (bytesRead == count)
                        {

                        var bytes = reader.ReadByte();

                             bytesRead = pngReader.Read(buffer, 0,buffer.Length); // check offset
                           

                            foreach (var item in textBuffer)
                            {
                                if (buffer.Contains(item))
                                {
                                    filestream.WriteByte(item);
                                }
                            }

                            buffer = new byte[count];

                        }



                        

                    }
                }

            }
            
        }
    }
}
