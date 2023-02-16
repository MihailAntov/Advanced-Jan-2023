using System;

namespace _02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());
            int currentRow = 0;
            int currentCol = 0;
            char[][] maze = new char[rows][];
            for(int row = 0; row < rows; row++)
            {
                string rowArgs = Console.ReadLine();
                maze[row] = new char[rowArgs.Length];
                for(int i = 0; i < rowArgs.Length; i++)
                {
                    maze[row][i] = rowArgs[i];
                    if (maze[row][i] == 'M')
                    {
                        currentRow = row;
                        currentCol = i;
                        maze[row][i] = '-';
                    }
                }
            }
            int cols = maze[0].Length;
            while(lives > 0)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                int bowserRow = int.Parse(commandArgs[1]);
                int bowserCol = int.Parse(commandArgs[2]);
                maze[bowserRow][bowserCol] = 'B';



                lives--;
                switch(command)
                {
                    case "W":
                        if(currentRow > 0)
                        {
                            currentRow--;
                        }
                        break;
                    case "S":
                        if (currentRow < rows - 1)
                        {
                            currentRow++;
                        }
                        break;
                    case "A":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        break;
                    case "D":
                        if (currentCol < cols-1)
                        {
                            currentCol++;
                        }
                        break;
                }

                switch (maze[currentRow][currentCol])
                {
                    case 'B':
                        lives -= 2;
                        if(lives > 0)
                        {
                            maze[currentRow][currentCol] = '-';
                        }
                        else
                        {
                            maze[currentRow][currentCol] = 'X';
                            Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                            Print();
                            return;
                        }
                        break;
                    case 'P':
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");

                        maze[currentRow][currentCol] = '-';
                        Print();
                        return;
                }
            }

            maze[currentRow][currentCol] = 'X';
            Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
            Print();
            return;


            void Print()
            {
                for(int row = 0; row < rows; row ++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(maze[row][col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
