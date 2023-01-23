namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
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
            using (FileStream readStream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long sizeOfHalf = readStream.Length / 2;
                long sizeOfOne = sizeOfHalf;
                long sizeOfTwo = sizeOfHalf;


                if(readStream.Length%2 != 0)
                {
                    sizeOfOne++;
                }

                using (FileStream writeStreamOne = new FileStream(partOneFilePath,FileMode.Create))
                {
                    byte[] buffer = new byte[sizeOfOne];
                    readStream.Read(buffer);
                    writeStreamOne.Write(buffer);
                }

                using (FileStream writeStreamTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[sizeOfTwo];
                    readStream.Read(buffer);
                    writeStreamTwo.Write(buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writeStream = new FileStream(joinedFilePath,FileMode.Create))
            {
                using (FileStream readStreamOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    using (FileStream readStreamTwo = new FileStream(partTwoFilePath, FileMode.Open))
                    {
                        byte[] bufferOne = new byte[readStreamOne.Length];
                        byte[] bufferTwo = new byte[readStreamTwo.Length];

                        readStreamOne.Read(bufferOne);
                        readStreamTwo.Read(bufferTwo);
                        writeStream.Write(bufferOne, 0, bufferOne.Length);
                        writeStream.Write(bufferTwo, 0, bufferTwo.Length);

                    }
                }
            }
        }
    }
}