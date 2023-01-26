using System;
using System.Linq;



Func<string, bool> filter = n => char.IsUpper(n[0]);

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(filter)
    .ToArray();

Console.WriteLine(String.Join("\n",input));