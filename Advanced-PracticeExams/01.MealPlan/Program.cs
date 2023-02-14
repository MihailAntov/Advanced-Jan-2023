using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> map = new Dictionary<string, int>
            {
                {"salad",350 },
                {"soup",490 },
                {"pasta",680 },
                {"steak",790 }
            };
            int mealsCount = 0;
            int currentCalories = 0;
            int currentMealCalories = 0;
            while(calories.Count > 0 && meals.Count > 0)
            {
                currentCalories = calories.Pop();

                if(currentMealCalories == 0)
                {
                    currentMealCalories = map[meals.Dequeue()];
                    mealsCount++;
                }
                
                if(currentMealCalories > currentCalories)
                {
                    currentMealCalories -= currentCalories;
                    
                }
                else
                {
                    currentCalories -= currentMealCalories;
                    currentMealCalories = 0;
                    
                    calories.Push(currentCalories);
                }
            }

            if(currentMealCalories > 0 && calories.Any())
            {
                calories.Push(calories.Pop() - currentMealCalories);
            }

            if(meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ",calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ",meals )}.");
            }


        }
    }
}
