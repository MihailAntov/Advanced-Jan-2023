using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int totalSwords = 0;
            Dictionary<int, string> weapons = new Dictionary<int, string>
            {
                {70,"Gladius" },
                {80,"Shamshir" },
                {90,"Katana" },
                {110,"Sabre" },
                {150,"Broadsword" }
            };

            Dictionary<string, int> crafted = new Dictionary<string, int>
            {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };

            while(steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();

                if(weapons.ContainsKey(currentSteel+currentCarbon))
                {
                    string weapon = weapons[currentSteel+currentCarbon];

                    totalSwords++;
                    crafted[weapon]++;

                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }

            if(totalSwords>0)
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if(steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if(carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach(KeyValuePair<string, int> sword in crafted
                .Where(n=>n.Value > 0)
                .OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
