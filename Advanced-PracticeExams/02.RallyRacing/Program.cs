using System;
int size = int.Parse(Console.ReadLine());

string[,] track = new string[size, size];

string racingNumber = Console.ReadLine();

for(int row = 0; row < size; row++)
{
    string[] rowArgs = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for(int col = 0; col < size; col++)
    {
        track[row, col] = rowArgs[col];
    }
}

int currentRow = 0;
int currentCol = 0;
int totalKms = 0;
string input;

string endMessage = $"Racing car {racingNumber} DNF.";

while ((input = Console.ReadLine())!= "End")
{
    switch(input)
    {
        case "left":
            currentCol--;
            break;
        case "right":
            currentCol++;
            break;
        case "up":
            currentRow--;
            break;
        case "down":
            currentRow++;
            break;
    }
    totalKms += 10;

    if (track[currentRow,currentCol] == "T")
    {
        HandleTunnel();
    }

    if (track[currentRow, currentCol] == "F")
    {
        Finish();
        break;
    }
}

Console.WriteLine(endMessage);
Console.WriteLine($"Distance covered {totalKms} km.");
Print();

void HandleTunnel()
{
    track[currentRow, currentCol] = ".";
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            if (track[i, j] == "T")
            {
                currentRow = i;
                currentCol = j;
                track[i, j] = ".";
                totalKms += 20;
            }
        }
    }
}

void Finish()
{
    endMessage = $"Racing car {racingNumber} finished the stage!";
}


void Print()
{
    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            if(currentRow == row && currentCol == col)
            {
                Console.Write("C");
                continue;
            }
            
            Console.Write(track[row, col]);
        }
        Console.WriteLine();
    }
}
