using System;
using System.Collections.Generic;

namespace _8.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            long n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];

            triangle[0] = new long[1] { 1 };


            for (int row = 1; row < n; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
            }

            foreach (long[] row in triangle)
            {
                Console.WriteLine(String.Join(" ", row));
            }

        }
    }
}
