using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PoisonousPlants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<long> plants = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(n=> long.Parse(n))
                .ToList();
            bool stable = false;
            int counter = 0;
            while(!stable)
            {
                stable = true;
                counter++;
                Queue<long> queue = new Queue<long>();
                queue.Enqueue(plants[0]);
                for (int i = 1; i < plants.Count; i++)
                {
                    
                    if (plants[i] <= plants[i-1])
                    {
                        queue.Enqueue(plants[i]);

                    }
                    else
                    {
                        stable = false;
                    }
                }
                plants.Clear();
                while(queue.Count > 0)
                {
                    plants.Add(queue.Dequeue());
                }
            }

            Console.WriteLine(counter-1);

        }
    }
}
