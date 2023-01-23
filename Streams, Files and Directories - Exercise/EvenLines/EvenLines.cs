namespace EvenLines
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            List<List<string>> results = new List<List<string>>();
            string output = string.Empty;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;

                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    if(counter % 2 == 0)
                    {
                        results.Add(line
                            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                            .ToList());
                    }
                    counter++;
                }
            }
            foreach(List<string> line in results)
            {
                line.Reverse();
                for (int i = 0; i < line.Count; i++)
                {
                    line[i] = line[i]
                        .Replace('-', '@')
                        .Replace(',', '@')
                        .Replace('.', '@')
                        .Replace('?', '@')
                        .Replace('!', '@');


                }
                output+=$"{String.Join(" ", line)}\n";
            }
            return output;
            
            
        }
    }
}
