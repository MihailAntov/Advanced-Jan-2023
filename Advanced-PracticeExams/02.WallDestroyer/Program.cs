using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;
            int holes = 0;
            int rods = 0;
            for (int row = 0; row < size; row++)
            {

                string rowArgs = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = rowArgs[col];
                    if(rowArgs[col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                        wall[row, col] = '*';
                        holes++;

                    }
                }
            }

            bool electrocuted = false;
            string command;
            while((command = Console.ReadLine())!= "End")
            {
                if(electrocuted)
                {
                    break;
                }
                int lastRow = currentRow;
                int lastCol = currentCol; 

                switch(command)
                {
                    case "up":
                        if(currentRow > 0)
                        {
                            currentRow--;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "down":
                        if (currentRow < size-1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "right":
                        if (currentCol < size-1)
                        {
                            currentCol++;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                }

                switch(wall[currentRow,currentCol])
                {
                    case 'R':
                        Console.WriteLine("Vanko hit a rod!");
                        rods++;
                        currentRow = lastRow;
                        currentCol = lastCol;

                        break;
                    case '*':
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                        break;
                    case 'C':
                        wall[currentRow, currentCol] = 'E';
                        electrocuted = true;
                        holes++;
                        break;
                    case '-':
                        wall[currentRow,currentCol] = '*';
                        holes++;
                        break;
                }

               
            }

            if(electrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                wall[currentRow, currentCol] = 'V';
            }

            for(int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
