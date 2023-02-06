using System;
using CustomStructures;

CustomList list = new CustomList();

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

list.RemoveAt(4);
list.RemoveAt(3);
list.RemoveAt(2);
list.Insert(1, 5);
list.Add(5);
list.Add(12);
list.RemoveAt(0);
list.RemoveAt(0);
list.RemoveAt(0);




for(int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}