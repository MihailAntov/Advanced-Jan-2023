namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (FileStream zipFile = File.Open(zipArchiveFilePath, FileMode.Create))
            {
                // File to be added to archive
                using (FileStream source1 = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (ZipArchive archive = new ZipArchive(zipFile))
                    {
                        // Add file to the archive
                        archive.CreateEntry(inputFilePath);
                        // ZIP file
                        
                    }
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(zipArchiveFilePath, fileName);
                archive.ExtractToDirectory(outputFilePath);
            }
        }
    }
}
