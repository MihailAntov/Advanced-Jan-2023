using System;
using System.Linq;

Func<int,int, int> findMin = FindMin;


Console.WriteLine(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray()
    .Aggregate(findMin));
    
    

static int FindMin(int n1, int n2)
{
    if(n1< n2)
    {
        return n1;
    }
    return n2;
}