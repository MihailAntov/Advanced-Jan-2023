using System;
using System.Linq;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = input[0];

    decimal grade = decimal.Parse(input[1]);

    if(!grades.ContainsKey(name))
    {
        grades.Add(name, new List<decimal>());
    }
    grades[name].Add(grade);
        
}

foreach(KeyValuePair<string, List<decimal>> entry in grades)
{

    Console.Write($"{entry.Key} -> ");
    foreach(decimal grade in entry.Value)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.Write($"(avg: {entry.Value.Average():f2})");
    Console.WriteLine();
}