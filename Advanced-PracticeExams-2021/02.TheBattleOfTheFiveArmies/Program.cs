using System;

namespace _02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string rowArgs = Console.ReadLine();
                map[row] = new char[rowArgs.Length];

                for(int col = 0; col < rowArgs.Length; col++)
                {
                    map[row][col] = rowArgs[col];
                    if (map[row][col] == 'A')
                    {
                        currentCol = col;
                        currentRow = row;
                        map[row][col] = '-';
                    }
                }
            }

            int cols = map[0].Length;
            while(armor > 0)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = inputArgs[0];
                int spawnRow = int.Parse(inputArgs[1]);
                int spawnCol = int.Parse(inputArgs[2]);
                map[spawnRow][spawnCol] = 'O';

                armor--;

                switch(direction)
                {
                    case "up":
                        if(currentRow > 0)
                        {
                            currentRow--;
                        }
                        break;
                    case "down":
                        if (currentRow < rows-1)
                        {
                            currentRow++;
                        }
                        break;
                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        break;
                    case "right":
                        if (currentCol < cols-1)
                        {
                            currentCol++;
                        }
                        break;
                }

                switch(map[currentRow][currentCol])
                {
                    case 'O':
                        armor -= 2;
                        if(armor <= 0)
                        {
                            map[currentRow][currentCol] = 'X';
                            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                            Print();
                            return;
                        }
                        else
                        {
                            map[currentRow][currentCol] = '-';
                        }
                        break;
                    case 'M':
                        map[currentRow][currentCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        Print();
                        return;
                }
            }
            map[currentRow][currentCol] = 'X';
            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
            Print();


            void Print()
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(map[row][col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
