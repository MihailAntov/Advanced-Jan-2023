using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

string input;

while((input = Console.ReadLine()) != "end")
{
    numbers = ActOnArray(numbers, GetOperation(input));
}

static int[] ActOnArray(int[] array, Func<int[], int[]> action)
{
    return action(array);
}

static Func<int[], int[]> GetOperation(string command)
{
    switch(command)
    {
        case "add":
        case "multiply":
        case "subtract":
            return n => n.Select(GetNumberOperation(command)).ToArray();
        case "print":
            return PrintArray;
        default:
            return null;
    }
}

static int[] PrintArray(int[] array)
{
    Console.WriteLine(String.Join(" ", array));
    return array; 
}

static Func<int, int> GetNumberOperation(string command)
{
    switch(command)
    {
        case "add": return n => n + 1;
        case "multiply": return n => n * 2;
        case "subtract": return n => n - 1;
        default:
            return null;
    }
}