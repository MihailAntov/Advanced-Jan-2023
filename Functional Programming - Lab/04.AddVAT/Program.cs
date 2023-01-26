using System;
using System.Linq;

Action<double> print = n => Console.WriteLine($"{n:F2}");

double[] nums = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => double.Parse(n))
    .Select(n => 1.2 * n)
    .ToArray();
ActOnArray(nums, print);

void ActOnArray(double[] array, Action<double> action)
{
    foreach(double item in array)
    {
        action(item);
    }
}

