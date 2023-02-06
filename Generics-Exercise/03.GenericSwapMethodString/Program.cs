using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> list = new List<string>();
            //int n = int.Parse(Console.ReadLine());
            //for(int i = 0; i < n; i++)
            //{
            //    list.Add(Console.ReadLine());
            //}

            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }



            int[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            list = GenericSwapListElements.Swap(list, arguments[0], arguments[1]);
            foreach (var e in list)
            {
                Console.WriteLine($"{e.GetType().FullName}: {e}");
            }


        }
    }
}