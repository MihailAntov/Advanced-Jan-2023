using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];
for (int i = 0; i < size; i++)
{
    int[] rowInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int j = 0; j < size; j++)
    {
        matrix[i, j] = rowInfo[j];
    }
}

int primaryDiagonal = 0;
int secondaryDiagonal = 0;

for (int i = 0; i < size; i++)
{
    primaryDiagonal += matrix[i, i];
    secondaryDiagonal += matrix[i, size -1 - i];
}

Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
