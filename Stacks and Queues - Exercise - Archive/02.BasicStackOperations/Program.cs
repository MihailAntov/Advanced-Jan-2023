using System;
using System.Linq;
using System.Collections.Generic;
namespace _02.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmdArgs = Console.ReadLine()
    .Split()
    .Select(n => int.Parse(n))
    .ToArray();

            int n = cmdArgs[0];
            int s = cmdArgs[1];
            int x = cmdArgs[2];

            int[] ints = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(ints[i]);
                if (i == ints.Length - 1)
                {
                    break;
                }
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    break;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
