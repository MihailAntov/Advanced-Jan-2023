using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.GroupNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            List<int> rem0 = new List<int>();
            List<int> rem1 = new List<int>();
            List<int> rem2 = new List<int>();

            foreach(int i in ints)
            {
                if (Math.Abs(i) % 3 == 0)
                {
                    rem0.Add(i);
                }
                else if (Math.Abs(i) % 3 == 1)
                {
                    rem1.Add(i);
                }
                else
                {
                    rem2.Add(i);
                }
            }

            int[][] results = new int[][] { rem0.ToArray(), rem1.ToArray(), rem2.ToArray() };

            for(int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(String.Join(" ", results[i]));
            }


        }
    }
}
