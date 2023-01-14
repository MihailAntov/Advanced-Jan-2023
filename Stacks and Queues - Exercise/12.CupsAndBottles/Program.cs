using System;
using System.Collections.Generic;
using System.Linq;

Queue<int> cups = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> bottles = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
int wastedWater = 0;
int currentCup = cups.Peek();
while(cups.Any())
{
    if(!bottles.Any())
    {
        break;
    }
    
    int currentBottle = bottles.Peek();
   
    
    if(currentBottle >= currentCup)
    {
        wastedWater += currentBottle - currentCup;
        cups.Dequeue();
        bottles.Pop();
        if(cups.Any())
        {
            currentCup = cups.Peek();
        }
        else
        {
            break;
        }
        
    }
    else
    {
        currentCup -= currentBottle;
        bottles.Pop();
    }
}

if(cups.Any())
{
    Console.WriteLine($"Cups: {String.Join(" ",cups)}");
}
else
{
    Console.WriteLine($"Bottles: {String.Join(" ",bottles)}");
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");

