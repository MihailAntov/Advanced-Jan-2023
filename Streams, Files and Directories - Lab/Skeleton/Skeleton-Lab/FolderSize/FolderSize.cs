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
            double size = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*",SearchOption.AllDirectories);
            foreach(FileInfo info in infos)
            {
                size += info.Length;
            }

            size = (double)size / 1024;
            

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{size} KB");
            }
        }
    }
}
