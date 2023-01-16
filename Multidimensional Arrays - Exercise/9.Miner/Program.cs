using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

int currentRow = -1;
int currentCol = -1;
int coals = 0;
int totalCoals = 0;

char[,] field = new char[size, size];

for (int row = 0; row < size; row++)
{
    char[] rowInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = rowInfo[col];
        if (field[row,col] == 's')
        {
            currentRow = row;
            currentCol = col;
        }

        if (field[row,col] == 'c')
        {
            totalCoals++;
        }
    }
}

for(int i = 0; i < commands.Length; i++)
{
    switch(commands[i])
    {
        case "left":
            if (currentCol != 0)
            {
                currentCol--;
            }
            break;
        case "right":
            if(currentCol != size-1)
            {
                currentCol++;
            }
            break;
        case "up":
            if(currentRow != 0)
            {
                currentRow--;
            }
            break;
        case "down":
            if(currentRow!= size-1)
            {
                currentRow++;
            }
            break;
    }


    switch (field[currentRow, currentCol])
    {
        case 'c':
            coals++;
            field[currentRow, currentCol] = '*';
            if(coals == totalCoals)
            {
                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                return;
            }
            break;
        case 'e':
            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
            return;
        default:
            break;
    }

}

Console.WriteLine($"{coals} coals left. ({currentRow}, {currentCol})");

