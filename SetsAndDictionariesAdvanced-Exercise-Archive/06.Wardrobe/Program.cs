using System;
using System.Collections.Generic;
namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputArgs[0];
                string[] clothes = inputArgs[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string c in clothes)
                {
                    if (!wardrobe[color].ContainsKey(c))
                    {
                        wardrobe[color].Add(c, 0);
                    }
                    wardrobe[color][c]++;
                }


            }

            string[] queryArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string queryColor = queryArgs[0];
            string queryClothing = queryArgs[1];

            foreach (KeyValuePair<string, Dictionary<string, int>> entry in wardrobe)
            {
                Console.WriteLine($"{entry.Key} clothes:");
                foreach (KeyValuePair<string, int> clothing in entry.Value)
                {
                    string addition = (entry.Key == queryColor && clothing.Key == queryClothing ? " (found!)" : string.Empty);
                    Console.WriteLine($"* {clothing.Key} - {clothing.Value}{addition}");

                }
            }
        }
    }
}
