using System;
using System.Collections.Generic;


int number = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);



Func<string, int, bool> filter = (str, number) =>
{
    int sum = 0;
    foreach (char c in str)
    {
        sum += (int)c;
    }
    return sum >= number;
};

Func<string[], Func<string, int, bool>, int, string> findFirst = (names, filter, number) =>
{
    foreach (string name in names)
    {
        if (filter(name, number))
        {
            return name;
        }
    }
    return null;
};


Console.WriteLine(findFirst(names, filter, number));
