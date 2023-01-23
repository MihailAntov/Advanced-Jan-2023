namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> dictionary = new Dictionary<string, List<FileInfo>>();
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = dir.GetFiles("*",SearchOption.TopDirectoryOnly);

            foreach(FileInfo file in files)
            {
                if(!dictionary.ContainsKey(file.Extension))
                {
                    dictionary.Add(file.Extension, new List<FileInfo>());
                }
                dictionary[file.Extension].Add(file);
            }
            string result = string.Empty;

            foreach(KeyValuePair<string, List<FileInfo>> entry in dictionary
                .OrderByDescending(n=>n.Value.Count)
                .ThenBy(n=>n.Key))
            {
                result += $"{entry.Key}\n";
                foreach(FileInfo file in entry.Value.OrderBy(n=>n.Length))
                {
                    result += $"--{file.Name} - {(double)file.Length/1024:F3}kb\n";
                }
            }

            return result;

        }

        

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), reportFileName);
            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                byte[] textBuffer = new byte[textContent.Length];
                writer.Write(textBuffer,0,textContent.Length);
            }
        }
    }
}
