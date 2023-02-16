using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vowels = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<string> consonants = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Dictionary<string,HashSet<string>> words = new Dictionary<string, HashSet<string>> 
            {
                {"pear", new HashSet<string>() },
                {"flour", new HashSet<string>() },
                {"pork", new HashSet<string>() },
                {"olive", new HashSet<string>()}
            };

            while(consonants.Count > 0)
            {
                string vowel = vowels.Dequeue();
                string consonant = consonants.Pop();
                foreach(var word in words)
                {
                    if(word.Key.Contains(vowel))
                    {
                        word.Value.Add(vowel);
                    }

                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);

            }

            IEnumerable<KeyValuePair<string, HashSet<string>>> filteredWords = words.Where(n => n.Value.Count == n.Key.Length);
            Console.WriteLine($"Words found: {filteredWords.Count()}");
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word.Key);
            }

        }
    }
}
