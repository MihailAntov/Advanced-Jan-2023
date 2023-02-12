using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> milk = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            List<Drink> drinks = new List<Drink>()
{
    {new Drink("Cortado",50) },
    {new Drink("Espresso",75) },
    {new Drink("Capuccino",100) },
    {new Drink("Americano",150) },
    {new Drink("Latte",200) }

};

            Dictionary<string, int> drinksMade = new Dictionary<string,int>();

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentMilk = milk.Pop();
                int nextQuantity = currentMilk + coffee.Dequeue();

                Drink drinkToBeMade = drinks.FirstOrDefault(n => n.Quantity == nextQuantity);
                if (drinkToBeMade != null)
                {
                    if (!drinksMade.ContainsKey(drinkToBeMade.Name))
                    {
                        drinksMade.Add(drinkToBeMade.Name, 0);
                    }
                    drinksMade[drinkToBeMade.Name]++;
                }
                else
                {
                    milk.Push(currentMilk - 5);
                }
            }

            if (milk.Count == 0 && coffee.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine($"Coffee left: none");
            }

            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine($"Milk left: none");
            }

            foreach (KeyValuePair<string, int> drink in drinksMade.OrderBy(n => n.Value).ThenByDescending(n => n.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }


    }
    class Drink
    {
        public Drink(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}


