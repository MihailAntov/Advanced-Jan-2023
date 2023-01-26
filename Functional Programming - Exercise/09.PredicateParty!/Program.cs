using System;
using System.Collections.Generic;
using System.Linq;

string[] guests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string input;

while ((input = Console.ReadLine()) != "Party!")
{
    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Func<string[], Predicate<string>, string[]> command = GetCommand(cmdArgs[0]);
    Predicate<string> filter = GetFilter(cmdArgs[1], cmdArgs[2]);

    guests = command(guests, filter);
}

if(guests.Length > 0)
{
    Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
    return;
}
Console.WriteLine("Nobody is going to the party!");



Func<string[], Predicate<string>, string[]> GetCommand(string command)
{
    switch (command)
    {
        case "Double":
            return DoubleNames;
        case "Remove":
            return RemoveNames;
        default:
            return null;
    }
}

Predicate<string> GetFilter(string filter, string criteria)
{
    switch (filter)
    {
        case "StartsWith": return n => StartsWith(n, criteria);
        case "EndsWith": return n => EndsWith(n, criteria);
        case "Length": return n => LengthIs(n, int.Parse(criteria));
        default:
            return null;

    }
}

static string[] DoubleNames(string[] array, Predicate<string> filter)
{
    List<String> results = new List<string>();
    foreach(string s in array)
    {
        if(filter(s))
        {
            results.Add(s);
        }
        results.Add(s);
    }
    return results.ToArray();
}

static string[] RemoveNames(string[] array, Predicate<string> filter)
{
    List<string> results = array.ToList();
    foreach(string s in array)
    {
        if(filter(s))
        {
           results.Remove(s);
        }
    }
    return results.ToArray();
}



static bool StartsWith(string word, string criteria)
{
    
    if(criteria.Length > word.Length)
    {
        return false;
    }
    for(int i = 0; i < criteria.Length; i++)
    {
        if (word[i]!= criteria[i])
        {
            return false;
        }
    }

    return true;
}

static bool EndsWith(string word, string criteria)
{
    if (criteria.Length > word.Length)
    {
        return false;
    }

    for (int i = 0; i < criteria.Length;i++)
    {
        if (word[word.Length-1-i] != criteria[criteria.Length-1-i])
        {
            return false;
        }
    }

    return true;
}

static bool LengthIs(string word, int criteria)
{
    return word.Length == criteria; 
}


