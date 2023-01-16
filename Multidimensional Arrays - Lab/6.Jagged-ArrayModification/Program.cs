using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

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

string command;

while((command = Console.ReadLine())!= "END")
{
    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int row = int.Parse(commandInfo[1]);
    int col = int.Parse(commandInfo[2]);

    if(row < 0 || row >= size || col < 0 || col >= size)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }
    int value = int.Parse(commandInfo[3]);
    switch(commandInfo[0])
    {
        case "Add":
            matrix[row, col] += value;

            break;
        case "Subtract":
            matrix[row, col] -= value;
            break;
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}