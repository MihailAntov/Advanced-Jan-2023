using System;
using System.Linq;

int[] nums = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(n=>int.Parse(n))
    .ToArray();

Console.WriteLine(nums.Length);
Console.WriteLine(nums.Sum());