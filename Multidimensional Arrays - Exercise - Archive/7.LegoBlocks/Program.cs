using System;
using System.Linq;

namespace _7.LegoBlocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] firstArray = new int[n][];
            int[][] secondArray = new int[n][];
            for(int row = 0; row < n; row++)
            {
                firstArray[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                
            }

            for(int row = 0; row < n; row++)
            {
                secondArray[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int lengthOfFirstLine = firstArray[0].Length + secondArray[0].Length;
            bool match = true;
            for(int i = 1; i < n; i++)
            {
                if(firstArray[i].Length + secondArray[i].Length != lengthOfFirstLine)
                {
                    match = false;
                    break;
                }
            }

            if(match)
            {
                for (int i = 0; i < n; i++)
                {
                    int[] result = firstArray[i].Concat(secondArray[i].Reverse()).ToArray();
                    Console.WriteLine($"[{String.Join(", ",result)}]");
                }
            }
            else
            {
                int result = 0;
                for(int i = 0; i < n; i++)
                {
                    result+= firstArray[i].Length + secondArray[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {result}");
            }


        }
    }
}
