using System.Collections.Generic;
using System;
using System.Linq;

int[] lengths = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

HashSet<int> firstSet = new HashSet<int>();
HashSet<int> secondSet = new HashSet<int>();
for (int i = 0; i < lengths[0]; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < lengths[1]; i++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

Console.WriteLine(String.Join(" ",firstSet.Where(n=>secondSet.Contains(n))));
