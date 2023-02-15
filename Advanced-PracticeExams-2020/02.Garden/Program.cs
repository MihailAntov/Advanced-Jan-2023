using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            List<(int, int)> flowers = new List<(int, int)>();
            int[,] garden = new int[rows, cols];

            for(int row = 0; row < rows; row++)
            {
                
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string input; 

            while((input = Console.ReadLine())!= "Bloom Bloom Plow")
            {
                int[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                int row = cmdArgs[0];
                int col = cmdArgs[1];

                if(row <0 || row >= rows || col < 0  || col >= cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                flowers.Add((row, col));
            }

            foreach((int,int) flower in flowers)
            {
                int flowerRow = flower.Item1;
                int flowerCol = flower.Item2;

                garden[flowerRow, flowerCol]--;

                for(int row = 0; row < rows; row++)
                {
                    garden[row, flowerCol]++;
                }

                for (int col = 0; col < cols; col++)
                {
                    garden[flowerRow, col]++;
                }
            }

            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(garden[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
