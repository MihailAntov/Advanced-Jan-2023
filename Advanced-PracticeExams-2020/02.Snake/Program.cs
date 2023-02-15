using System;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] map = new char[size, size];
            int currentRow = 0;
            int currentCol = 0;
            int food = 0;
            for(int row = 0; row < size; row++)
            {
                string rowArgs = Console.ReadLine();
                for(int col = 0; col < size; col++)
                {
                    map[row, col] = rowArgs[col];
                    if(map[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            while(food < 10)
            {
                map[currentRow, currentCol] = '.';
                string command = Console.ReadLine();
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

                if (currentRow < 0 || currentRow >= size || currentCol < 0 || currentCol >= size)
                {
                    EndGame();
                    break;
                }
                    

                switch(map[currentRow,currentCol])
                {
                    case 'B':
                        MoveThroughTunnel();
                        break;
                    case '*':
                        food++;
                        if(food>= 10)
                        {
                            map[currentRow, currentCol] = 'S';
                            EndGame();
                            break;
                        }
                        break;
                }

                map[currentRow, currentCol] = 'S';


            }

            void MoveThroughTunnel()
            {
                map[currentRow, currentCol] = '.';
                for(int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (map[row,col] == 'B')
                        {
                            currentRow = row;
                            currentCol = col;
                            return;
                        }
                    }
                }
            }

            void EndGame()
            {
                
                if (food >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                }
                else
                {
                    Console.WriteLine("Game over!");
                }

                Console.WriteLine($"Food eaten: {food}");

                for (int row = 0; row < size; row++)
                {
                    {
                        for(int col = 0; col < size; col++)
                        {
                            Console.Write(map[row,col]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
