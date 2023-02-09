using System;
using CustomDoublyLinkedList;
using System.Diagnostics;
using System.Collections.Generic;
namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
            ints.AddLast(1);
            ints.AddLast(2);
            ints.AddLast(3);
            ints.AddLast(4);

            DoublyLinkedList<string> strings = new DoublyLinkedList<string>();
            strings.AddFirst("one");
            strings.AddFirst("two");
            strings.AddFirst("three");
            strings.AddFirst("four");

            foreach(var item in ints)
            {
                Console.WriteLine(item);
            }

            foreach(string item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}

//Stopwatch watch = new Stopwatch();
//watch.Start();
//DoublyLinkedList<int> list = new DoublyLinkedList<int>();
//list.AddLast(5);
//list.AddLast(6);
//list.AddLast(7);
//list.AddLast(8);
//list.AddLast(9);
//list.AddFirst(4);
//list.AddFirst(3);
//list.AddFirst(2);
//list.AddFirst(1);

//int[] array = list.ToArray();
//Console.WriteLine(String.Join(" ",array));

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





