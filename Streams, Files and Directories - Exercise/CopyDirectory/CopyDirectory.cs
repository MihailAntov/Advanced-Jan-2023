namespace CopyDirectory
{
    using System;
    using System.IO;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo dir = new DirectoryInfo(inputPath);
            FileInfo[] files = dir.GetFiles();

            DirectoryInfo outputDir = new DirectoryInfo(outputPath);
            if(outputDir != null)
            {
                Directory.Delete(outputPath,true);
            }
            outputDir = Directory.CreateDirectory(outputPath);
            foreach(FileInfo file in files)
            {
                string outputFilePath = Path.Combine(outputPath, file.Name);
                File.WriteAllBytes(outputFilePath, File.ReadAllBytes(file.FullName));
            }
        }
    }
}
