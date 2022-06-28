namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";


            var fileNameOnly = Path.GetFileName(inputFile);
            ZipFileToArchive(inputFile, zipArchiveFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {

            using ZipArchive zip = ZipFile.Open(zipArchiveFilePath,ZipArchiveMode.Create);

            zip.CreateEntryFromFile(inputFilePath, "copyMe.png");
            




        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {

            using ZipArchive zip = ZipFile.OpenRead(zipArchiveFilePath);
            zip.GetEntry(fileName).ExtractToFile(outputFilePath);
            



        }
    }
}
