using System;
using System.Linq;

namespace _2.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for(int row = 0; row < size; row++)
            {
                int[] ints = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for(int col = 0; col < size; col++)
                {
                    matrix[row, col] = ints[col];
                }
            }

            int primDiag = 0;
            int secDiag = 0;
            for(int i = 0; i < size; i ++)
            {
                primDiag+= matrix[i,i];
                secDiag += matrix[i, size - 1 - i];
            }

            Console.WriteLine(Math.Abs(primDiag-secDiag));
        }
    }
}
