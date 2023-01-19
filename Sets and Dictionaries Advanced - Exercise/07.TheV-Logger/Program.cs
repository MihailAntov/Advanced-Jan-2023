using System;
using System.Collections.Generic;
using System.Linq;

string input;
Dictionary<string, HashSet<string>> vloggers = new Dictionary<string, HashSet<string>>();
while((input = Console.ReadLine()) != "Statistics")
{
    string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    
    string vlogger = inputArgs[0];
    string command = inputArgs[1];

    switch(command)
    {
        case "joined":
            if(!vloggers.ContainsKey(vlogger))
            {
                vloggers.Add(vlogger, new HashSet<string>());
            }

            break;

        case "followed":
            string vloggerFollowed = inputArgs[2];

            if (!vloggers.ContainsKey(vlogger)
                || !vloggers.ContainsKey(vloggerFollowed)
                || vlogger == vloggerFollowed
                || vloggers[vloggerFollowed].Contains(vlogger))
            {
                continue;
            }

            vloggers[vloggerFollowed].Add(vlogger);

            break;

    }
}

vloggers = vloggers
    .OrderByDescending(n => n.Value.Count)
    .ThenBy(n => vloggers.Where(m => m.Value.Contains(n.Key)).Count())
    .ToDictionary(n => n.Key, n => n.Value);
int counter = 1;
Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
KeyValuePair<string, HashSet<string>> first = vloggers.First();
Console.WriteLine($"{counter++}. {first.Key} : {first.Value.Count} followers, {vloggers.Where(m => m.Value.Contains(first.Key)).Count()} following");
foreach(string follower in first.Value.OrderBy(n=>n))
{
    Console.WriteLine($"*  {follower}");
}

Dictionary<string, HashSet<string>> rest = vloggers.Skip(1).ToDictionary(n => n.Key, n => n.Value);

foreach(KeyValuePair<string, HashSet<string>> vlogger in rest)
{
    Console.WriteLine($"{counter++}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggers.Where(m => m.Value.Contains(vlogger.Key)).Count()} following");
}