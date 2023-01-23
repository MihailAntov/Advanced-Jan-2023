namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader readerOne = new StreamReader(firstInputFilePath))
                {
                    using (StreamReader readerTwo = new StreamReader(secondInputFilePath))
                    {
                        while(!(readerOne.EndOfStream && readerTwo.EndOfStream))
                        {
                            string lineOne = readerOne.ReadLine();
                            string lineTwo = readerTwo.ReadLine();

                            if(lineOne != null)
                            {
                                writer.WriteLine(lineOne);
                            }

                            if(lineTwo != null)
                            {
                                writer.WriteLine(lineTwo);
                            }
                        }
                    }
                }


            }
        }
    }
}
