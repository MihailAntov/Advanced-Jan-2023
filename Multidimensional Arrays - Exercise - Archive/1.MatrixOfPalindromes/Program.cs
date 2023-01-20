using System;
using System.Linq;

namespace _1.MatrixOfPalindromes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int rows = parameters[0];
            int columns = parameters[1];

            string[,] matrix = new string[rows, columns];

            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    //matrix[row, col] = $"{(char)(61+row)}{(char)(61+row+col)}{(char)(61+ row)}";
                    Console.Write($"{(char)(97 + row)}{(char)(97 + row + col)}{(char)(97 + row)} ");
                }
                Console.WriteLine();
            }


        }
    }
}
