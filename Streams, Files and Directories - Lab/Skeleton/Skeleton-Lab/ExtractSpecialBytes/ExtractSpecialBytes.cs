namespace ExtractBytes
{
    using System;
    using System.IO;
    using System.Linq;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            
                byte[] specialBytes = File.ReadAllLines(bytesFilePath)
                    .Select(byte.Parse)
                    .ToArray();

                byte[] inputBytes = File.ReadAllBytes(binaryFilePath);

                byte[] outputBytes = inputBytes
                    .Where(n=>specialBytes.Contains(n))
                    .ToArray();

                File.WriteAllBytes(outputPath, outputBytes);

            
        }
    }
}
