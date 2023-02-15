using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int claimedItems = 0;

            while(firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstValue = firstBox.Peek();
                int secondValue = secondBox.Peek();

                if((firstValue + secondValue) % 2 == 0)
                {
                    claimedItems += firstValue + secondValue;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());

                }
            }

            if(firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if(claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
