namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {

        /* Write a program that traverses a given directory for all files with the given extension. Search through the first level of the directory only. Write information about each found file in a text file named report.txt and it should be saved on the Desktop. The files should be grouped by their extension. Extensions should be ordered by the count of their files descending, then by name alphabetically. Files under an extension should be ordered by their size. report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.*/

        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] dir = Directory.GetFiles(inputFolderPath);
            int count = 0;
            FileInfo[] files = new FileInfo[dir.Length];
            foreach (var file in dir)
            {
                files[count] = new FileInfo(dir[count]);
                count++;
            }

            var fileDictionary = new Dictionary<string, List<FileInfo>>();



            foreach (var file in files)
            {
                if (!fileDictionary.ContainsKey(file.Extension))
                {
                    fileDictionary[file.Extension] = new List<FileInfo>();
                }

                fileDictionary[file.Extension].Add(file);
            }

            fileDictionary = fileDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);

            var sortedListOfValues = new List<List<FileInfo>>();
            for (int i = 0; i < fileDictionary.Count; i++)
            {
                sortedListOfValues.Add(fileDictionary.Values.ToList()[i].OrderBy(x => x.Length).ToList());
                fileDictionary[fileDictionary.Keys.ToList()[i]] = sortedListOfValues[i];
            }

            StringBuilder reportContent = new StringBuilder();

            foreach (var extension in fileDictionary)
            {
                reportContent.AppendLine(extension.Key);
                foreach (var file in extension.Value)
                {
                    reportContent.AppendLine($"--{file.Name} - {file.Length / 1024.0}kb");
                }

            }


            return reportContent.ToString();
        }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);
            using (StreamWriter writer = new StreamWriter($"{strPath}{reportFileName}"))
            {
                writer.Write(textContent);
            }
    }

}
}
