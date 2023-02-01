using System;
using ImplementingLinkedList;
using System.Diagnostics;
using System.Collections.Generic;


Stopwatch watch = new Stopwatch();
watch.Start();
DoublyLinkedList list = new DoublyLinkedList();
list.AddLast(5);
list.AddLast(6);
list.AddLast(7);
list.AddLast(8);
list.AddLast(9);
list.AddFirst(4);
list.AddFirst(3);
list.AddFirst(2);
list.AddFirst(1);

//for(int i = 0; i < 300000; i++)
//{
//    list.AddFirst(i);
//}

//Console.WriteLine($"Peak : {list.PeakFirst()}");
//Console.WriteLine($"Dequeue : {list.RemoveFirst()}");
//Console.WriteLine($"Pop : {list.RemoveLast()}");


//watch.Stop();
//Console.WriteLine(watch.ElapsedMilliseconds);

//Stopwatch watch2 = new Stopwatch();

//watch2.Start();

//List<int> list2 = new List<int>();

//for (int i = 0; i < 300000; i++)
//{
//    list2.Insert(0,i);
//}

//Console.WriteLine(list2[0]);
//Console.WriteLine(list2[list2.Count-1]);

//watch2.Stop();

//Console.WriteLine(watch2.ElapsedMilliseconds);


list.ForEach(n => Console.WriteLine(n.Value));

list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();
list.RemoveFirst();


