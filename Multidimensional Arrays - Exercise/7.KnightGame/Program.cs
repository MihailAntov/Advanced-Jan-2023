using System;
using System.Linq;

int size = int.Parse(Console.ReadLine());

char[,] board = new char[size, size];

for (int row = 0; row < size; row ++)
{
    string rowInput = Console.ReadLine();
    for (int col = 0; col < size; col ++)
    {
        board[row, col] = rowInput[col];
    }
}

int removeCounter = 0;
CheckBoard();
Console.WriteLine(removeCounter);

void CheckBoard()
{
    int maxAttacks = 0;
    int maxAttackRow = -1;
    int maxAttackColumn = -1;
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            if (board[row, col] != 'K')
            {
                continue;
            }
            int totalAttacks = CheckCell(row - 1, col - 2)
                + CheckCell(row - 1, col + 2)
                + CheckCell(row + 1, col - 2)
                + CheckCell(row + 1, col + 2)
                + CheckCell(row - 2, col - 1)
                + CheckCell(row - 2, col + 1)
                + CheckCell(row + 2, col - 1)
                + CheckCell(row + 2, col + 1);

            if(totalAttacks > maxAttacks)
            {
                maxAttacks = totalAttacks;
                maxAttackRow = row;
                maxAttackColumn = col;
            }

        }
    }

    if(maxAttacks>0)
    {
        board[maxAttackRow, maxAttackColumn] = '0';
        removeCounter++;
        CheckBoard();
    }

    
}

int CheckCell(int row, int col)
{
    if(row < 0 || row >= size || col < 0 || col >= size)
    {
        return 0;
    }

    if (board[row, col] == 'K')
    {
        return 1;
    }
    else
    {
        return 0;
    }
}
