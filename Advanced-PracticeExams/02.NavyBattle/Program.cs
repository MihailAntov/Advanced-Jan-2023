using System;

int size = int.Parse(Console.ReadLine());

char[,] battlefield = new char[size, size];

int currentRow = 0;
int currentCol = 0;
int damage = 0;
int cruisers = 0;

for (int row = 0; row < size; row++)
{
    string rowInfo = Console.ReadLine();
    for(int col = 0; col < size; col++)
    {
        battlefield[row, col] = rowInfo[col];
        if (rowInfo[col] == 'S')
        {
            currentRow = row;
            currentCol = col;
        }

        if (rowInfo[col] == 'C')
        {
            cruisers++;
        }
    }
}

while(damage < 3 && cruisers > 0)
{
    string command = Console.ReadLine();
    battlefield[currentRow, currentCol] = '-';
    switch(command)
    {
        case "up":
            currentRow--;
            break;
        case "down":
            currentRow++;
            break;
        case "left":
            currentCol--;
            break;
        case "right":
            currentCol++;
            break;
    }
    
    switch (battlefield[currentRow,currentCol])
    {
        case 'C':
            cruisers--;
            break;
        case '*':
            damage++;
            break;
    }
    battlefield[currentRow, currentCol] = 'S';
}

if(damage == 3)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currentRow}, {currentCol}]!");
}
else if(cruisers == 0)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}

for(int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(battlefield[row, col]);
    }
    Console.WriteLine();
}