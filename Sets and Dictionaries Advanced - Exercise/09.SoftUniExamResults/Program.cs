using System;
using System.Collections.Generic;
using System.Linq;

string input;
Dictionary<string, int> people = new Dictionary<string,int>();
Dictionary<string, int> languages = new Dictionary<string, int>();
HashSet<string> bans = new HashSet<string>();
while((input = Console.ReadLine()) != "exam finished")
{
    string[] inputArgs = input.Split("-");

    string username = inputArgs[0];
    if (inputArgs.Length == 2)
    {
        bans.Add(username);
        
        continue;
    }

    
    string language = inputArgs[1];
    int points = int.Parse(inputArgs[2]);

    if(!languages.ContainsKey(language))
    {
        languages.Add(language, 0);
    }

    languages[language]++;

    if (!people.ContainsKey(username))
    {
        people.Add(username, 0);
    }

    if(points> people[username])
    {
        people[username] = points;
    }
    

}

Console.WriteLine("Results:");

foreach(KeyValuePair<string, int> student in people.Where(n=>!bans.Contains(n.Key)).OrderByDescending(n=>n.Value).ThenBy(n=>n.Key))
{
    
        Console.WriteLine($"{student.Key} | {student.Value}");
    
}

Console.WriteLine("Submissions:");
foreach (var language in languages.OrderByDescending(n=>n.Value).ThenBy(n=>n.Key))
{
    
    Console.WriteLine($"{language.Key} - {language.Value}");
}
