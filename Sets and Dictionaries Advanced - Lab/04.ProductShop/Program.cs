using System;
using System.Collections.Generic;
using System.Linq;

string input;

Dictionary<string,Dictionary<string, double> > stores = new Dictionary<string, Dictionary<string, double>>();

while((input = Console.ReadLine()) != "Revision")
{
    string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string store = inputArgs[0];
    string product = inputArgs[1];
    double price = double.Parse(inputArgs[2]);


    if(!stores.ContainsKey(store))
    {
        stores.Add(store, new Dictionary<string, double>());
    }

    if (!stores[store].ContainsKey(product))
    {
        stores[store].Add(product, 0);
    }

    stores[store][product] = price;
}

foreach(KeyValuePair<string, Dictionary<string, double>> store in stores.OrderBy(n=>n.Key))
{
    Console.WriteLine($"{store.Key}->");
    foreach(KeyValuePair<string, double> product in store.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}