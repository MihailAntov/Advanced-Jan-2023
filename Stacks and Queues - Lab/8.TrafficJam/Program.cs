using System;
using System.Collections.Generic;
namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input;
            int counter = 0;
            while((input = Console.ReadLine())!= "end")
            {
                if(input == "green")
                {
                    int carsToPass = Math.Min(capacity, cars.Count);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
