

using System;
using System.Collections.Generic;

namespace _1.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> word = new Stack<string>();
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                word.Push(c.ToString());
            }

            int length = word.Count;
            for (int i = 0; i < length; i++)
            {
                Console.Write(word.Pop());
            }

        }
    }
}