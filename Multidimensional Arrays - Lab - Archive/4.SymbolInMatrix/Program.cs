using System;
using System.Linq;

namespace _4.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
