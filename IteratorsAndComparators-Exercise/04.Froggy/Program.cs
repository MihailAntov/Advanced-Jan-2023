using System;
using Froggy;
using System.Linq;

int[] stones = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Lake lake = new Lake(stones);
Console.WriteLine(String.Join(", ",lake));