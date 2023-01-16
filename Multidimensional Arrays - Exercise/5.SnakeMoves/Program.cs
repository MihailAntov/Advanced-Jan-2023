using System;
using System.Collections.Generic;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];
char[,] isle = new char[rows, cols];
Queue<char> snake = new Queue<char>(Console.ReadLine());

for (int row = 0; row < rows; row++)
{

    if (row % 2 == 0)
    {
        //left to right
        for (int col = 0; col < cols; col++)
        {
            MoveSnake(row, col);
        }

    }
    else
    {
        //right to left

        for (int col = cols-1; col >= 0; col --)
        {
            MoveSnake(row, col);
        }
    }

}
PrintSnake();


void MoveSnake(int row, int col)
{
    char currentChar = snake.Dequeue();
    snake.Enqueue(currentChar);
    isle[row, col] = currentChar;
}

void PrintSnake()
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(isle[row, col]);
        }
        Console.WriteLine();
    }
}
