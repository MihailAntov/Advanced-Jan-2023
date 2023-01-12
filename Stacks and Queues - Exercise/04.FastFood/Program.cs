using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(n=>int.Parse(n)));

            Console.WriteLine(orders.Max());

            while(orders.Count > 0)
            {
                if(orders.Peek() <= food)
                {
                    food -= orders.Dequeue();
                }
                else
                {
                    break;
                }
                
            }

            if(orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }


        }
    }
}
