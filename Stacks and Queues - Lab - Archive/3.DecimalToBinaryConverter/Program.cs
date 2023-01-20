using System;
using System.Collections.Generic;
namespace _3.DecimalToBinaryConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int number = int.Parse(Console.ReadLine());

            if(number==0)
            {
                Console.WriteLine(0);
                return;
            }

            while(number > 0)
            {
                stack.Push(number%2);
                number = number / 2;
            }

            while(stack.Count>0)
            {
                Console.Write(stack.Pop());
            }


        }
    }
}
