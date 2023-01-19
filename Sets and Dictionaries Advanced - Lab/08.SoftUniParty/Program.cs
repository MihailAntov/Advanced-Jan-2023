using System;
using System.Collections.Generic;
using System.Linq;

string input;
HashSet<string> guests = new HashSet<string>();
HashSet<string> vipGuests = new HashSet<string>();
//switched dictionary with two sets to avoid slow orderby(value) operation
//Dictionary<string, bool> guests = new Dictionary<string, bool>();
while((input = Console.ReadLine()) != "PARTY")
{
    //if(!guests.ContainsKey(input))
    //{
    //    guests.Add(input, char.IsDigit(input[0]) ? true : false);
    //}

    if (char.IsDigit(input[0]))
    {
        vipGuests.Add(input);
    }
    else
    {
        guests.Add(input);
    }
    
}

while ((input = Console.ReadLine()) != "END")
{
    //guests.Remove(input);

    if (char.IsDigit(input[0]))
    {
        vipGuests.Remove(input);
    }
    else
    {
        guests.Remove(input);
    }
}


Console.WriteLine(guests.Count + vipGuests.Count);

foreach(string guest in vipGuests)
{
    Console.WriteLine(guest);
}

foreach (string guest in guests)
{
    Console.WriteLine(guest);
}


//Console.WriteLine(guests.Count);
//foreach (KeyValuePair<string, bool> guest in guests.OrderByDescending(n => n.Value))
//{
//    Console.WriteLine(guest.Key);
//}