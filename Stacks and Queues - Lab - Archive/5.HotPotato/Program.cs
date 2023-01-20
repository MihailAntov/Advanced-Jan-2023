using System;
using System.Collections.Generic;
namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split(" "));
            int count = int.Parse(Console.ReadLine());

            while (children.Count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Dequeue()}");

        }
    }
}
