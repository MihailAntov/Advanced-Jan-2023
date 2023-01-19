using System;
using System.Collections.Generic;
using System.Linq;


int n = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if(!numbers.ContainsKey(currentNumber))
    {
        numbers.Add(currentNumber, 0);
    }

    numbers[currentNumber]++;
}

Console.WriteLine(numbers.First(n=>n.Value % 2 == 0).Key);