using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine().Split(" ");
                foreach (string s in strings)
                {
                    elements.Add(s);
                }
            }

            Console.WriteLine(String.Join(" ", elements.OrderBy(n => n)));

        }
    }
}
