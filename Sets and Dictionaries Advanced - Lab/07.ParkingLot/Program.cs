using System;
using System.Collections.Generic;

string input;
HashSet<string> cars = new HashSet<string>();
while((input = Console.ReadLine())!= "END")
{
    string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    if (inputArgs[0] == "IN")
    {
        cars.Add(inputArgs[1]);
    }
    else if (inputArgs[0] == "OUT")
    {
        cars.Remove(inputArgs[1]);
    }
}

if(cars.Count>0)
{
    foreach(string car in cars)
    {
        Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine($"Parking Lot is Empty");
}
