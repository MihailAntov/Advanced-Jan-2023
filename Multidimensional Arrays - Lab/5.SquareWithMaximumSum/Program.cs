using System;
using System.Linq;

int[] matrixDimensions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

int rows = matrixDimensions[0];
int cols = matrixDimensions[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] rowInfo = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(n => int.Parse(n))
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}
int squareSize = 2;
int maxSum = int.MinValue;
int[,] resultMatrix = new int[squareSize,squareSize];
for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        int currentSum =
            matrix[row, col]
            + matrix[row, col + 1]
            + matrix[row + 1, col]
            + matrix[row + 1, col + 1];

        if(currentSum> maxSum)
        {
            maxSum = currentSum;
            for(int resultRow = 0; resultRow < squareSize; resultRow++)
            {
                for (int resultCol = 0; resultCol < squareSize; resultCol++)
                {
                    resultMatrix[resultRow, resultCol] = matrix[row + resultRow, col + resultCol];
                }
            }

        }
    }
}

for(int row = 0; row < resultMatrix.GetLength(0); row++)
{
    for (int col = 0; col < resultMatrix.GetLength(1); col++)
    {
        Console.Write($"{resultMatrix[row,col]} ");
    }
    Console.WriteLine();
}
Console.WriteLine(maxSum);