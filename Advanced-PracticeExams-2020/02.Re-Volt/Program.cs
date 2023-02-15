using System;

namespace _02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int currentCol = 0;
            int currentRow = 0;
            bool won = false;
            for(int row = 0; row < size; row++)
            {
                string rowArgs = Console.ReadLine();
                for(int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowArgs[col];
                    if (matrix[row,col] == 'f')
                    {
                        matrix[row, col] = '-';
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            

            for (int turn = 1; turn <= count; turn++)
            {
                string command = Console.ReadLine();
                int lastRow = currentRow;
                int lastCol = currentCol;
                Move(command);

                switch(matrix[currentRow,currentCol])
                {
                    case 'B':
                        Move(command);
                        break;
                    case 'T':
                        currentRow = lastRow;
                        currentCol = lastCol;
                        break;
                    case 'F':
                        won = true;
                        EndGame();
                        return;
                }

                //matrix[currentRow, currentCol] = 'f';

                

            }
            EndGame();
            return;

            void EndGame()
            {
                if(won)
                {
                    Console.WriteLine("Player won!");
                }
                else
                {
                    Console.WriteLine("Player lost!");
                }

                for(int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if(row == currentRow && col == currentCol)
                        {
                            Console.Write('f');
                        }
                        else
                        {
                            Console.Write(matrix[row, col]);
                        }
                        
                    }
                    Console.WriteLine();
                }
            }

            void Move(string command)
            {
                
                switch (command)
                {
                    case "up":
                        currentRow = (currentRow + size - 1) % size;
                        break;
                    case "down":
                        currentRow = (currentRow + size + 1) % size;
                        break;
                    case "left":
                        currentCol = (currentCol + size - 1) % size;
                        break;
                    case "right":
                        currentCol = (currentCol + size + 1) % size;
                        break;
                }
                
            }
        }
    }
}
