using System;
using System.Collections.Generic;

string text = Console.ReadLine();

SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

foreach(char c in text)
{
    if(!chars.ContainsKey(c))
    {
        chars.Add(c, 0);
    }
    chars[c]++;
}

foreach(KeyValuePair<char,int> entry in chars)
{
    Console.WriteLine($"{entry.Key}: {entry.Value} time/s");
}