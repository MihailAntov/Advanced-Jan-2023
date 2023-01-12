using System;
using System.Collections.Generic;
using System.Linq;
namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(n=>int.Parse(n))
                .ToArray());
            List<int> results = new List<int>();
            while(queue.Count>0)
            {
                if(queue.Peek() % 2 == 0)
                {
                    results.Add(queue.Peek());
                }

                queue.Dequeue();
            }

            Console.WriteLine(String.Join(", ", results));
        }
    }
}
