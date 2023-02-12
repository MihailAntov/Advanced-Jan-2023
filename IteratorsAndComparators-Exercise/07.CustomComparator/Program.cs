using System;
using System.Linq;



int[] ints = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

//CustomComparer comparer = new CustomComparer();

//Array.Sort(ints, comparer);

Func<int, int, int> comparator = (x, y) =>
{
    if (x % 2 == 0 && y % 2 != 0)
    {
        return -1;
    }

    if (x % 2 != 0 && y % 2 == 0)
    {
        return 1;
    }

    return x.CompareTo(y);
};


Array.Sort(ints, (x,y) => comparator(x,y));

Console.WriteLine(String.Join(" ",ints));