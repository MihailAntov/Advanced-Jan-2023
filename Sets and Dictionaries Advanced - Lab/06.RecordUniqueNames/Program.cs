using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());
HashSet<string> names = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    names.Add(Console.ReadLine());
}

Console.WriteLine(String.Join("\n",names));