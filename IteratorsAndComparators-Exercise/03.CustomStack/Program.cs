using System;
using System.Linq;
using _03.CustomStack;

CStack<string> items = new CStack<string>();

string input;

while((input = Console.ReadLine()) != "END")
{
    if(input == "Pop")
    {
        try
        {
            items.Pop();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
        }
        continue;
    }



    string[] inputParams = input
        .Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries)
        .Skip(1)
        .ToArray();

    items.Push(inputParams);
}

foreach(var item in items)
{
    Console.WriteLine(item);
}
foreach (var item in items)
{
    Console.WriteLine(item);
}