using System;
using System.Linq;
using System.Collections.Generic;

int caffeine = 0;

Stack<int> caffeineStack = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n)));

Queue<int> drinkQueue = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n)));

while(caffeineStack.Any() && drinkQueue.Any())
{
    int nextCaffeine = caffeineStack.Pop();
    int nextDrink = drinkQueue.Dequeue();
    int nextAmount = nextCaffeine * nextDrink;

    if(caffeine + nextAmount > 300)
    {
        drinkQueue.Enqueue(nextDrink);

        caffeine -= 30;

        if(caffeine < 0)
        {
            caffeine = 0;
        }
    }
    else
    {
        
        caffeine += nextAmount;
        
    }
}

if(drinkQueue.Any())
{
    Console.WriteLine($"Drinks left: {string.Join(", ",drinkQueue)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {caffeine} mg caffeine.");

