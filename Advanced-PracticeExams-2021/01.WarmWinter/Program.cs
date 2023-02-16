﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> scarves = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> results = new List<int>();

            while(hats.Count > 0 && scarves.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarves.Peek();

                if(hat > scarf)
                {
                    results.Add(hat + scarf);
                    hats.Pop();
                    scarves.Dequeue();
                }    
                else if (hat < scarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarves.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {results.Max()}");
            Console.WriteLine(String.Join(" ",results));
        }
    }
}
