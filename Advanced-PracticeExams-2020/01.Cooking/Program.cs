using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, string> recipes = new Dictionary<int, string>
            {
                {25,"Bread" },
                {50,"Cake" },
                {75,"Pastry" },
                {100,"Fruit Pie" }

            };


            Dictionary<string, int> cookedFood = new Dictionary<string, int>
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Fruit Pie", 0 },
                {"Pastry", 0 }
                
            };



            while(liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquidValue = liquids.Dequeue();
                int ingredientValue = ingredients.Pop();

                if(recipes.ContainsKey(liquidValue+ingredientValue))
                {
                    string food = recipes[liquidValue+ingredientValue];
                    cookedFood[food]++;
                }
                else
                {
                    ingredients.Push(ingredientValue + 3);
                }
            }

            if(cookedFood.Any(n=>n.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if(liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if(ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach(KeyValuePair<string, int> food in cookedFood.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }


        }
    }

    
}
