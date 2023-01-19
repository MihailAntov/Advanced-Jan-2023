using System;
using System.Collections.Generic;
using System.Linq;

string input;

Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

while((input = Console.ReadLine()) != "Lumpawaroo")
{
    string[] inputArgs = new string[] { } ;
    string user = string.Empty;
    string side = string.Empty;
    if (input.Contains("|"))
    {
        inputArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
        user = inputArgs[1];
        side = inputArgs[0];

        if (!sides.Values.Any(n=>n.Contains(user)))
        {
            if(!sides.ContainsKey(side))
            {
                sides.Add(side, new List<string>());
            }
            sides[side].Add(user);
        }
    }
    else if (input.Contains("->"))
    {
        inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
        user = inputArgs[0];
        side = inputArgs[1];

        if (!sides.Values.Any(n => n.Contains(user)))
        {
            if (!sides.ContainsKey(side))
            {
                sides.Add(side, new List<string>());
            }
            sides[side].Add(user);
        }
        else
        {
            foreach (KeyValuePair<string, List<string>> entry in sides)
            {
                entry.Value.Remove(user);
            }

            if (!sides.ContainsKey(side))
            {
                sides.Add(side, new List<string>());
            }
            sides[side].Add(user);

            

        }
        Console.WriteLine($"{user} joins the {side} side!");
    }
}

foreach(KeyValuePair<string, List<string>> entry in sides
    .OrderByDescending(n=>n.Value.Count)
    .ThenBy(n=>n.Key))
{
    if(!entry.Value.Any())
    {
        continue;
    }

    Console.WriteLine($"Side: {entry.Key}, Members: {entry.Value.Count}");

    foreach(string jedi in entry.Value.OrderBy(n=>n))
    {
        Console.WriteLine($"! {jedi}");
    }
}