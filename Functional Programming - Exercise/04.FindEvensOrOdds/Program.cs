using System;
using System.Linq;

int[] bounds = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int lower = bounds[0];
int upper = bounds[1];

string command = Console.ReadLine();
Func<int, int, int[]> getRange = GetRangeFunc(lower, upper);
Console.WriteLine(String.Join(" ",getRange(lower, upper)
    .Where(GetFilter(command))));


static Func<int, bool> GetFilter(string command)
{
    switch (command)
    {
        case "odd":
            return n => n % 2 != 0;
        case "even":
            return n => n % 2 == 0; 
        default:
            return null;
    }
               
}

Func<int, int, int[]> GetRangeFunc(int lower, int upper)
{
    int[] result = new int[upper - lower + 1];
    for(int i = lower; i <= upper; i++)
    {
        result[i-lower] = i;
    }
    return (lower,upper) => result;
}