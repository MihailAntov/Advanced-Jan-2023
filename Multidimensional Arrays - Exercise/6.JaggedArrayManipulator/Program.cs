using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());

int[][] matrix = new int[rows][];

for (int row = 0; row < rows; row++)
{
    matrix[row] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

for (int row = 0; row < rows-1; row++)
{
    if (matrix[row].Length == matrix[row+1].Length)
    {
        for (int col = 0; col < matrix[row].Length; col++)
        {
            matrix[row][col] *= 2;
            matrix[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < matrix[row].Length; col++)
        {
            matrix[row][col] /= 2;
            
        }

        for (int col = 0; col < matrix[row+1].Length; col++)
        {
            matrix[row + 1][col] /= 2;
        }
    }
}

string input;

while((input = Console.ReadLine())!= "End")
{
    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = cmdArgs[0];

    int row = int.Parse(cmdArgs[1]);
    int col = int.Parse(cmdArgs[2]);
    int value = int.Parse(cmdArgs[3]);

    if(row < 0 || row >= rows || col < 0 || col >= matrix[row].Length)
    {
        continue;
    }

    switch(command)
    {
        case "Add":
            matrix[row][col] += value;
            break;
        case "Subtract":
            matrix[row][col] -= value;
            break;
    }
}

foreach (int[] row in matrix)
{
    Console.WriteLine(String.Join(" ",row));
}