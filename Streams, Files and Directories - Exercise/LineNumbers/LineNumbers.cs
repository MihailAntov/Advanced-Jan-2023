namespace LineNumbers
{
    using System;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int counter = 0;
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        int letters = 0;
                        int punctuation = 0;
                        foreach(char c in line)
                        {
                            if (char.IsLetter(c))
                            {
                                letters++;
                            }
                            else if (char.IsPunctuation(c))
                            {
                                punctuation++;
                            }
                        }

                        line = $"Line {++counter}: {line} ({letters})({punctuation})";

                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
