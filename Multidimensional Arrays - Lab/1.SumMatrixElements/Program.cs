using System;
using System.Collections.Generic;
using System.Linq;

int[] matrixDimensions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();
int rows = matrixDimensions[0];
int cols = matrixDimensions[1];
int[,] matrix = new int[rows,cols];
int sum = 0;
for (int row = 0; row < rows; row++)
{
    int[] rowInfo = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(n => int.Parse(n))
        .ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

foreach(int n in matrix)
{
    sum += n;
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sum);
