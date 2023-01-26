using System;
using System.Linq;
using System.Collections.Generic;

string[] reservations = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
List<Filter> filters = new List<Filter>();

string input;

while((input = Console.ReadLine())!= "Print")
{
    string[] inputArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

    switch(inputArgs[0])
    {
        case "Add filter":
            filters.Add(new Filter(inputArgs[1], inputArgs[2]));
            break;
        case "Remove filter":
            filters.RemoveAll(n=> n.Condition == inputArgs[1] && n.Value == inputArgs[2]);
            break;
        default:
            break;
    }
}

foreach(Filter filter in filters)
{
    reservations = reservations.Where(n => !filter.Predicate(n)).ToArray();
}

Console.WriteLine(String.Join(" ",reservations));


class Filter
{
    public Filter(string condition, string value)
    {
        Value = value;
        Condition = condition;
        Predicate = GetFilter(condition, value);
    }

    public string Value { get; set; }
    public string Condition { get; set; }
    public Predicate<string> Predicate { get; set; }
    static Predicate<string> GetFilter(string filterName, string value)
    {
        switch (filterName)
        {
            case "Starts with": return n => StartsWith(n, value);
            case "Ends with": return n => EndsWith(n, value);
            case "Length": return n => IsLength(n, int.Parse(value));
            case "Contains": return n => Contains(n, value);
            default:
                return null;
        }
    }

    static bool StartsWith(string word, string criteria)
    {
        if (criteria.Length > word.Length)
        {
            return false;
        }
        for (int i = 0; i < criteria.Length; i++)
        {
            if (word[i] != criteria[i])
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

        for (int i = 0; i < criteria.Length; i++)
        {
            if (word[word.Length - 1 - i] != criteria[criteria.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
    static bool IsLength(string word, int criteria)
    {
        return word.Length == criteria;
    }
    static bool Contains(string word, string criteria)
    {
        return word.Contains(criteria);
    }

}