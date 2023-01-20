using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indices.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = indices.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }

        }
    }
}