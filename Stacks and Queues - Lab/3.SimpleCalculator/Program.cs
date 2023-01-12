using System;
using System.Collections.Generic;
namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> numbers = new Stack<string>(Console.ReadLine().Split(' '));
            int sum = 0;
            while(numbers.Count > 1)
            {
                int number = int.Parse(numbers.Pop().ToString());
                
                if(numbers.Pop() == "-")
                {
                    number *= -1;
                }
                sum += number;
                
            }
            
            sum += int.Parse(numbers.Pop());

            Console.WriteLine(sum);
        }
    }
}
