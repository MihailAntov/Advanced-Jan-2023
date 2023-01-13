using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> clothes = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n)));

int capacity = int.Parse(Console.ReadLine());

int rackCount = 1;
int currentAmount = 0;
while (clothes.Any())
{
    if(currentAmount + clothes.Peek() > capacity)
    {
        rackCount++;
        currentAmount = clothes.Pop();
    }
    else if (currentAmount + clothes.Peek() == capacity)
    {
        
        currentAmount = 0;
        clothes.Pop();
        if(clothes.Any())
        {
            rackCount++;
        }
    }
    else
    {
        currentAmount += clothes.Pop();
    }
}

Console.WriteLine(rackCount);
