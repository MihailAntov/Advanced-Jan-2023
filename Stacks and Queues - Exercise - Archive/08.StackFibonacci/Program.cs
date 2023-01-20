using System;
using System.Collections.Generic;

namespace _08.StackFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<long> fib = new Stack<long>();
            fib.Push(0);
            fib.Push(1);

            long n = long.Parse(Console.ReadLine());

            for(int i = 1; i < n; i++)
            {
                long prevNum = fib.Pop();
                long secPrevNum = fib.Peek();
                fib.Push(prevNum);
                fib.Push(secPrevNum + prevNum);
            }

            Console.WriteLine(fib.Peek());
        }
    }
}
