using System;
using System.Collections.Generic;
namespace _01.GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for(int i = 0; i< n; i++)
            {
                double box = double.Parse(Console.ReadLine());
                list.Add(box);
            }

            double comparer = double.Parse(Console.ReadLine());

            Console.WriteLine(GenericCount.Count(list,comparer));


        }
    }
}