using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int target = int.Parse(Console.ReadLine());
            int answer = 0;
            while(tasks.Count > 0 && threads.Count > 0)
            {
                int taskValue = tasks.Peek();
                int threadValue = threads.Peek();

                if(threadValue >= taskValue)
                {
                    tasks.Pop();
                }
                

                if(taskValue == target)
                {
                    answer = threadValue;
                    break;
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {answer} killed task {target}");
            Console.WriteLine(String.Join(" ",threads));

        }
    }
}
