using System;
using System.Linq;
using System.Collections.Generic;

double[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

Dictionary<double, int> ocurrences = new Dictionary<double, int>();

foreach(double number in numbers)
{
    if(!ocurrences.ContainsKey(number))
    {
        ocurrences.Add(number, 0);
    }

    ocurrences[number]++;
}

foreach(KeyValuePair<double,int> entry in ocurrences)
{
    Console.WriteLine($"{entry.Key} - {entry.Value} times");
}