using System;
using System.Linq;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

int[] divisors = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(n=>int.Parse(n))
    .ToArray();

int[] numbers = GetRange(n);

Func<int, int[], bool> filter = IsValid;
numbers = numbers.Where(n => IsValid(n, divisors)).ToArray();
Console.WriteLine(String.Join(" ",numbers));



bool IsValid(int n, int[] divisors)
{
    foreach(int divisor in divisors)
    {
        if (n % divisor != 0)
        {
            return false;
        }
    }
    
    return true;
}

static int[] GetRange(int limit)
{
    int[] result = new int[limit];

    for(int i = 1; i <= limit; i++)
    {
        result[i-1] = i;
    }
    return result;
}