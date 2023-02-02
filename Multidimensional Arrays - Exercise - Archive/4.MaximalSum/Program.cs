using System;
using System.Linq;

namespace _4.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int[] matrixDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }
            int squareSize = 3;
            int maxSum = int.MinValue;
            int[,] resultMatrix = new int[squareSize, squareSize];
            for (int row = 0; row < matrix.GetLength(0) + 1 - squareSize; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) + 1 - squareSize; col++)
                {

                    int currentSum = 0;
                    for (int i = 0; i < squareSize; i++)
                    {
                        for (int j = 0; j < squareSize; j++)
                        {
                            currentSum += matrix[row + i, col + j];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        for (int resultRow = 0; resultRow < squareSize; resultRow++)
                        {
                            for (int resultCol = 0; resultCol < squareSize; resultCol++)
                            {
                                resultMatrix[resultRow, resultCol] = matrix[row + resultRow, col + resultCol];
                            }
                        }

                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write($"{resultMatrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
