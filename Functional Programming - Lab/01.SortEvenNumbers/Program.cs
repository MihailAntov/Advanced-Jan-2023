using System;
using System.Linq;

int[] nums = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .Where(n => n % 2 == 0)
    .OrderBy(n => n)
    .ToArray();

Console.WriteLine(String.Join(", ",nums));