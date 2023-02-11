using System;
using System.Linq;
using NSListyIterator;


ListyIterator<string> listy = new ListyIterator<string>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray()[1..]);
string input;

while((input = Console.ReadLine())!= "END")
{
    string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    string command = inputArgs[0];
    
    switch(command)
    {
        case "Move":
            Console.WriteLine(listy.Move());
            break;
        case "Print":
            listy.Print();
            break;
        case "HasNext":
            Console.WriteLine(listy.HasNext());
            
            break;
        case "PrintAll":
            listy.PrintAll();
            break;
    }
}