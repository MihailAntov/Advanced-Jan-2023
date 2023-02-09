using System;
using System.Collections.Generic;
using EqualityLogic;



SortedSet<Person> sortedSet = new SortedSet<Person> ();
HashSet<Person> hashSet = new HashSet<Person>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] inputArgs = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = inputArgs[0];
    int age = int.Parse(inputArgs[1]);

    Person currentPerson = new Person(name, age);
    sortedSet.Add(currentPerson);
    hashSet.Add(currentPerson);
}

Console.WriteLine(sortedSet.Count);
Console.WriteLine(hashSet.Count);