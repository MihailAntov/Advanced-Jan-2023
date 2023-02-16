using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> capacity = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int waste = 0;
            while(capacity.Count > 0 && plates.Count > 0)
            {
                int guest = capacity.Dequeue();
                int plate = plates.Pop();

                guest -= plate;
                if(guest <= 0)
                {
                    waste -= guest; 
                }
                else
                {
                    capacity.Enqueue(guest);
                    for(int i = 0; i < capacity.Count-1; i++)
                    {
                        capacity.Enqueue(capacity.Dequeue());
                    }
                }
            }

            if(plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ",plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", capacity)}");
            }

            Console.WriteLine($"Wasted grams of food: {waste}");


        }
    }
}
