using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] rowInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

string[] bombArgs = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach(string bomb in bombArgs)
{
    int[] coords = bomb.Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    int bombRow = coords[0];
    int bombCol = coords[1];
    Explode(bombRow, bombCol);

}

int sum = 0;
int count = 0;
foreach(int cell in matrix)
{
    if(cell>0)
    {
        sum += cell;
        count++;
    }
}
Console.WriteLine($"Alive cells: {count}");
Console.WriteLine($"Sum: {sum}");
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }
    Console.WriteLine();
}

void Explode(int row, int col)
{
    if (matrix[row,col] <= 0)
    {
        return;
    }

    int strength = matrix[row, col];
    DamageCell(row, col+1, strength);
    DamageCell(row, col-1, strength);
    DamageCell(row+1, col-1, strength);
    DamageCell(row+1, col, strength);
    DamageCell(row+1, col+1, strength);
    DamageCell(row-1, col-1, strength);
    DamageCell(row-1, col, strength);
    DamageCell(row-1, col+1, strength);
    matrix[row, col] = 0;

}

void DamageCell(int row, int col, int strength)
{
    if(row < 0 || row >= size || col < 0 || col >= size)
    {
        return;
    }
    if(matrix[row, col] > 0)
    {
        matrix[row, col] -= strength;
    }
    
}