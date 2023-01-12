using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            string input;

            while((input = Console.ReadLine().ToLower())!= "end")
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];
                if(command == "add")
                {
                    numbers.Push(int.Parse(cmdArgs[1]));
                    numbers.Push(int.Parse(cmdArgs[2]));
                }
                else if (command == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if(count > numbers.Count)
                    {
                        continue;
                    }

                    for(int i = 0; i < count; i++)
                    {
                        numbers.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
