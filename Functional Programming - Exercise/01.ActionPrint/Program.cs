using System;
using System.Linq;

Action<string> print = s => Console.WriteLine(s);

string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
ActOnArray(print, words);

static void ActOnArray(Action<string> action, string[] array)
{
    foreach(string word in array)
    {
        action(word);
    }
}