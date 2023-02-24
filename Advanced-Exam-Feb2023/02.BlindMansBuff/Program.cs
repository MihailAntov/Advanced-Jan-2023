using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

int currentRow = 0;
int currentCol = 0;
int moves = 0;
int touches = 0;

char[,] map = new char[rows, cols];
for (int row = 0; row < rows; row++)
{

    char[] rowArgs = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        map[row, col] = rowArgs[col];
        if (map[row,col] == 'B')
        {
            currentRow = row;
            currentCol = col;
            map[row, col] = '-';
        }
    }
}

string input;

while((input = Console.ReadLine())!= "Finish")
{
    switch(input)
    {
        case "up":
            TryMove(-1, 0);
            break;
        case "down":
            TryMove(1, 0);
            break;
        case "left":
            TryMove(0, -1);
            break;
        case "right":
            TryMove(0, 1);
            break;
    }

    if (map[currentRow,currentCol] == 'P')
    {
        touches++;
        map[currentRow, currentCol] = '-';
    }

    if(touches == 3)
    {
        break;
    }
}


Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touches} Moves made: {moves}");


void TryMove(int rowChange, int colChange)
{
    int newRow = currentRow + rowChange;
    int newCol = currentCol + colChange;

    if(newRow < 0 || newRow >= rows)
    {
        return;
    }

    if(newCol < 0 || newCol >= cols )
    {
        return;
    }

    if(map[newRow,newCol] == 'O')
    {
        return;
    }

    moves++;
    currentCol = newCol;
    currentRow = newRow;
}