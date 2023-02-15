using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, string> map = new Dictionary<int, string>
            {
                {40,"Datura Bombs" },
                {60,"Cherry Bombs" },
                {120,"Smoke Decoy Bombs" }
            };
            bool filled = false;

            Dictionary<string, int> pouch = new Dictionary<string, int>
            {
                {"Datura Bombs",0 },
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs",0 }
            };
            while(effects.Any() && casings.Any())
            {
                int currentValue = effects.Peek() + casings.Peek();

                if(map.ContainsKey(currentValue))
                {
                    string bomb = map[currentValue];
                    pouch[bomb]++;

                    casings.Pop();
                    effects.Dequeue();

                    if(pouch.Count == 3 && pouch.All(n=> n.Value >=3))
                    {
                        filled = true;
                        break;
                    }
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                }
            }

            if(filled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if(effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ",effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if(casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach(KeyValuePair<string, int> bomb in pouch.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
