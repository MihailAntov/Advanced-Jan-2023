using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
List<Person> people = new List<Person>();
for (int i = 0; i < n; i++)
{
    string[] personArgs = Console.ReadLine().Split(", ");
    people.Add(new Person(personArgs[0], int.Parse(personArgs[1])));
}

string condition = Console.ReadLine();
int filterAge = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

people = Filter(GetFilter(condition, filterAge),people);
ActOnList(GetFormatAction(format),people);

static List<Person> Filter(Func<Person, bool> filter, List<Person> people)
{
    List<Person> filteredList = new List<Person>();
    foreach(Person person in people)
    {
        if(filter(person))
        {
            filteredList.Add(person);
        }
    }

    return filteredList;
}

static void ActOnList(Action<Person> action, List<Person> people)
{
    foreach(Person person in people)
    {
        action(person);
    }
}

static Func<Person, bool> GetFilter(string condition, int age)
{
    if(condition == "younger")
    {
        return n => n.Age < age;
    }
    else if (condition == "older")
    {
        return n=>n.Age >= age;
    }
    else
    {
        return null;
    }
}

static Action<Person> GetFormatAction (string format)
{
    switch(format)
    {
        case "name": return n => Console.WriteLine(n.Name);
        case "age": return n=> Console.WriteLine(n.Age);
        case "name age": return n => Console.WriteLine($"{n.Name} - {n.Age}");
        default:
            return null;
    }
}



class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}