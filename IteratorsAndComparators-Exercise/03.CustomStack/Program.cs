using System;
using System.Linq;
using _03.CustomStack;

CStack<int> ints = new CStack<int>();

string input;

while((input = Console.ReadLine()) != "END")
{
    if(input == "Pop")
    {
        
        ints.Pop();
        continue;
    }

    
    

    int[] inputParams = input.Substring(5)
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(n=>int.Parse(n))
        .ToArray();

    ints.Push(inputParams);
}

foreach(var item in ints)
{
    Console.WriteLine(item);
}
foreach (var item in ints)
{
    Console.WriteLine(item);
}