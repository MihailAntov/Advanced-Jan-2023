namespace CopyBinaryFile
{
    using System;
    using System.IO;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream stream = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writerStream = new FileStream(outputFilePath,FileMode.Create))
                {
                    byte[] readerBuffer = new byte[stream.Length];
                    stream.Read(readerBuffer, 0, readerBuffer.Length);
                    writerStream.Write(readerBuffer,0, readerBuffer.Length);
                }
            }
        }
    }
}
