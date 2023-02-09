using System;
using ComparingObjects;
using System.Collections.Generic;


string input;
List<Person> people = new List<Person>();
while((input = Console.ReadLine()) != "END")
{
    string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = inputArgs[0];
    int age = int.Parse(inputArgs[1]);
    string town = inputArgs[2];

    people.Add(new Person(name, age, town));
}

int target = int.Parse(Console.ReadLine());

Person targetPerson = people[target - 1];

Person.CompareToAll(targetPerson, people);