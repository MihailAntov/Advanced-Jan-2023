namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();


            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                foreach(string s in wordReader.ReadToEnd().Split(" ",StringSplitOptions.RemoveEmptyEntries))
                {
                    wordCount.Add(s.ToLower(), 0);
                }
            }



            using (StreamReader reader = new StreamReader(textFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach(string s in reader.ReadToEnd().Split(new char[] {' ','.',',','?','!','-'},StringSplitOptions.RemoveEmptyEntries))
                    {
                        if(wordCount.ContainsKey(s.ToLower()))
                        {
                            wordCount[s.ToLower()]++;
                        }
                    }

                    foreach(KeyValuePair<string, int> word in wordCount.OrderByDescending(n=>n.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
