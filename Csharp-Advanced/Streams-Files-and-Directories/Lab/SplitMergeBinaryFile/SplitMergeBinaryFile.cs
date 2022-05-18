namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer1 = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (FileStream writer2 = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
                    {
                        long i = 0;
                        byte[] buffer = new byte[1];
                        while (i < reader.Length)
                        {
                            reader.Read(buffer, 0, buffer.Length);
                            if (i%2 == 0)
                            {
                                writer1.WriteByte(buffer[0]);
                            }
                            else
                            {
                                writer2.WriteByte(buffer[0]);
                            }

                            buffer = new byte[1];
                            i++;
                        }



                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream reader1 = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream reader2 = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
                {
                    
                    using (FileStream writer = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
                    {
                        long i = 0;
                        byte[] buffer = new byte[1];
                        while (i < reader1.Length + reader2.Length)
                        {
                            if (i % 2 == 0)
                            {
                            reader1.Read(buffer, 0, buffer.Length);
                            }
                            else
                            {
                                reader2.Read(buffer, 0, buffer.Length);
                            }

                                writer.WriteByte(buffer[0]);
                                
                            buffer = new byte[1];
                            i++;
                        }



                    }
                }
            }
        }
    }
}