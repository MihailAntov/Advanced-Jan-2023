using System;
using System.Linq;
using CustomComparator;


int[] ints = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

CustomComparer comparer = new CustomComparer();

Array.Sort(ints, comparer);

Console.WriteLine(String.Join(" ",ints));