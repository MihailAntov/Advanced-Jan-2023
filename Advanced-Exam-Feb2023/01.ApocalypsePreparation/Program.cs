using System;
using System.Collections.Generic;
using System.Linq;

Queue<int> textiles = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> medicaments = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<int, string> items = new Dictionary<int, string>
{
    {30,"Patch" },
    {40,"Bandage" },
    {100,"MedKit" }

};

Dictionary<string, int> crafted = new Dictionary<string, int>
{
    {"Patch",0 },
    {"Bandage",0 },
    {"MedKit",0 }
};

while(textiles.Count > 0 && medicaments.Count > 0)
{
    int textile = textiles.Dequeue();
    int medicament = medicaments.Pop();

    int sum = textile + medicament;

    if(items.ContainsKey(sum))
    {
        string itemName = items[sum];
        crafted[itemName]++;
    }
    else
    {
        if (sum >= 100)
        {
            crafted["MedKit"]++;
            if(sum > 100)
            {
                medicaments.Push((sum - 100)+medicaments.Pop());
            }
            
        }
        else 
        {
            medicaments.Push(medicament + 10);
        }
    }
}

if(textiles.Count == 0 && medicaments.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (textiles.Count == 0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (medicaments.Count == 0)
{
    Console.WriteLine("Medicaments are empty.");
}


foreach(KeyValuePair<string,int> item in crafted
    .Where(n=>n.Value > 0)
    .OrderByDescending(n=>n.Value)
    .ThenBy(n=>n.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

if(medicaments.Count > 0)
{
    Console.WriteLine($"Medicaments left: {string.Join(", ",medicaments)}");
}

if(textiles.Count >0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
