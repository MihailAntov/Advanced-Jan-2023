using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .OrderByDescending(n=>n)
    .ToArray();

int count = numbers.Length < 3 ? numbers.Length : 3;
    Console.WriteLine(String.Join(" ", numbers[..count]));

