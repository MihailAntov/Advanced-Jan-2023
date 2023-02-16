using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, string> recipes = new Dictionary<int, string>
            {
                {150,"Dipping sauce" },
                {250,"Green salad" },
                {300,"Chocolate cake" },
                {400,"Lobster" }
            };

            Dictionary<string, int> meals = new Dictionary<string, int>
            {
                {"Dipping sauce",0 },
                {"Green salad",0 },
                {"Chocolate cake",0 },
                {"Lobster",0 }
            };

            while(ingredients.Count > 0 && freshness.Count > 0)
            {
                int ingredient = ingredients.Dequeue();
                if(ingredient == 0)
                {
                    continue;
                }
                int fresh = freshness.Pop();

                if(recipes.ContainsKey(ingredient * fresh))
                {
                    string meal = recipes[ingredient * fresh];
                    meals[meal]++;
                }
                else
                {
                    ingredient += 5;
                    ingredients.Enqueue(ingredient);
                }

            }

            if(meals.Any(n=>n.Value == 0))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if(ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach(KeyValuePair<string, int> meal in meals.Where(n=>n.Value > 0 ).OrderBy(n=>n.Key))
            {
                Console.WriteLine($" # {meal.Key} --> {meal.Value}");
            }

        }
    }
}
