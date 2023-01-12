﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] cmdArgs = Console.ReadLine()
                    .Split(" ")
                    .Select(n=>int.Parse(n))
                    .ToArray();

                switch (cmdArgs[0])
                {
                    case 1:
                        stack.Push(cmdArgs[1]);
                        break;
                    case 2: 
                        if(stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        
                        break;

                    case 3:
                        if(stack.Count>0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ",stack));

        }
    }
}
