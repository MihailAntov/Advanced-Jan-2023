using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            int result = 0;
            while(stack.Count>0)
            {
                int currentNum = int.Parse(stack.Pop());

                char operation = stack.Count>0 ?  char.Parse(stack.Pop()) : '+';
                if(operation == '+')
                {
                    result+= currentNum;
                }
                else
                {
                    result -= currentNum;
                }

            }
            Console.WriteLine(result);

        }
    }
}
