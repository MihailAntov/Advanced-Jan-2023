using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterList = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            Stack<double> flourList = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));

            Dictionary<string, int> bakery = new Dictionary<string, int>
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 }
            };

            while(waterList.Count > 0 && flourList.Count > 0)
            {
                double water = waterList.Dequeue();
                double flour = flourList.Pop();
                double total = water + flour;
                if(water == flour)
                {
                    bakery["Croissant"]++;
                }
                else if(water == 0.4 * total && flour == 0.6 * total)
                {
                    bakery["Muffin"]++;
                }
                else if (water == 0.3 * total && flour == 0.7 * total)
                {
                    bakery["Baguette"]++;
                }
                else if (water == 0.2 * total && flour == 0.8 * total)
                {
                    bakery["Bagel"]++;
                }
                else 
                {
                    bakery["Croissant"]++;
                    
                    if(flour > water)
                    {
                        flour -= water;
                        flourList.Push(flour);

                    }
                }
            }

            foreach(KeyValuePair<string, int> food in bakery
                .Where(n=>n.Value > 0)
                .OrderByDescending(n=>n.Value)
                .ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{ food.Key}: {food.Value  }");
            }

            if(waterList.Count>0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",waterList)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourList.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourList)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
