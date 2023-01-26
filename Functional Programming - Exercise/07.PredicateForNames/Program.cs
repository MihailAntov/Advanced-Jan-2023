using System;
using System.Linq;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());
Func<string, int, bool> filter = IsValid;
string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

names = WhereCustom(names, filter);

Action<string> print = s => Console.WriteLine(s);
ActOnArray(print, names);


static void ActOnArray(Action<string> action, string[] array)
{
    foreach (string word in array)
    {
        action(word);
    }
}
string[] WhereCustom(string[] names, Func<string, int, bool> filter )
{
    List<string> results = new List<string>();

    foreach(string name in names)
    {
        if(filter(name,n))
        {
            results.Add(name);
        }
    }
    return results.ToArray();
}

bool IsValid (string name, int limit)
{
    return name.Length <= limit;
}