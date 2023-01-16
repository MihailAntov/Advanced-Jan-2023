using System;
using System.Linq;

int[] sizeArgs = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[sizeArgs[0], sizeArgs[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    char[] rowInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

int resultCounter = 0;
for (int row = 0; row < matrix.GetLength(0)-1; row++)
{
    for (int col = 0; col < matrix.GetLength(1)-1; col++)
    {
        char currentChar = matrix[row, col];
        if (matrix[row, col+1] == currentChar &&
            matrix[row+1, col] == currentChar &&
            matrix[row+1, col+1] == currentChar)
        {
            resultCounter++;
        }
    }
}

Console.WriteLine(resultCounter);


