using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> greys = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                {40,"Sink" },
                {50,"Oven" },
                {60,"Countertop" },
                {70,"Wall" }
            };

            Dictionary<string, int> tiles = new Dictionary<string, int>();

            while(greys.Count > 0 && whites.Count > 0)
            {
                int nextGrey = greys.Dequeue();
                int nextWhite = whites.Pop();


                if(nextGrey == nextWhite)
                {
                    int area = nextGrey + nextWhite;
                    if(map.ContainsKey(area))
                    {
                        string location = map[area];
                        if (!tiles.ContainsKey(location))
                        {
                            tiles.Add(location, 0);
                        }
                        tiles[location]++;
                    }
                    else
                    {
                        if (!tiles.ContainsKey("Floor"))
                        {
                            tiles.Add("Floor", 0);
                        }
                        tiles["Floor"]++;
                    }
                }
                else
                {
                    whites.Push(nextWhite / 2);
                    greys.Enqueue(nextGrey);
                }
            }

            if(whites.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whites)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greys.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greys)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }


            foreach(KeyValuePair<string, int> location in tiles
                .Where(n=>n.Value > 0)
                .OrderByDescending(n=>n.Value)
                .ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
