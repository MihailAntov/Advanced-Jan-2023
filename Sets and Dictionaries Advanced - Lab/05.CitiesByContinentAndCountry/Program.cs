using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();    
for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
    string continent = input[0];
    string country = input[1];
    string city= input[2];

    if(!continents.ContainsKey(continent))
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continents[continent].ContainsKey(country))
    {
        continents[continent].Add(country, new List<string>());
    }

    continents[continent][country].Add(city);
}

foreach(KeyValuePair<string, Dictionary<string, List<string>>> entry in continents)
{
    Console.WriteLine($"{entry.Key}:");
    foreach(KeyValuePair<string, List<string>> countryEntry in entry.Value)
    {
        Console.WriteLine($"{countryEntry.Key} -> {string.Join(", ",countryEntry.Value)}");
    }
}
