using System;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];


            int currentRow = 0;
            int currentCol = 0;
            int points = 0;
            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for(int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row,col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string input;
            
            while((input = Console.ReadLine()) != "End")
            {
                field[currentRow, currentCol] = '-';
                switch (input)
                {
                    case "up":
                        if(currentRow > 0)
                        {
                            currentRow--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "down":
                        if (currentRow < size-1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "left":
                        if (currentCol > 0)
                        {
                            currentCol--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "right":
                        if (currentCol < size-1)
                        {
                            currentCol++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                }

                switch (field[currentRow, currentCol])
                {
                    case 'S':
                        field[currentRow, currentCol] = '-';
                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (field[row, col] == 'S')
                                {
                                    currentRow = row;
                                    currentCol = col;
                                    points -= 3;
                                }
                            }
                        }
                        break;
                    case '-':
                        break;
                    default:
                        points += int.Parse(field[currentRow, currentCol].ToString());
                        field[currentRow, currentCol] = '-';
                        break;
                }

                field[currentRow, currentCol] = 'M';
                if (points >= 25)
                {
                    break;
                }
            }

            if(points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for(int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    

                    Console.Write(field[row, col]);

                }
                Console.WriteLine();
            }

            
        }
    }
}