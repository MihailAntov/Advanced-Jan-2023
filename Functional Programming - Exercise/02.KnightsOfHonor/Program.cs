using System;
using System.Linq;

Func<string, string> appendSir = n => $"Sir {n}";
Action<string> print = s => Console.WriteLine(s);

string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => appendSir(n))
    .ToArray();

ActOnArray(print, words);


static void ActOnArray(Action<string> action, string[] array)
{
    foreach (string word in array)
    {
        action(word);
    }
}
