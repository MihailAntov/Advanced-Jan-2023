using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.RadioactiveBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            bool won = false;
            bool dead = false;
            string result = string.Empty;
            int currentRow = -1;
            int currentCol = -1;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInfo[col];
                    if (matrix[row, col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            foreach (char command in commands)
            {
                if (dead || won)
                {
                    break;
                }
                matrix[currentRow, currentCol] = '.';
                switch (command)
                {
                    case 'U':
                        if (currentRow == 0)
                        {
                            won = true;
                            break;
                        }
                        currentRow--;

                        break;
                    case 'D':
                        if (currentRow == rows - 1)
                        {
                            won = true;
                            break;
                        }
                        currentRow++;
                        break;
                    case 'L':

                        if (currentCol == 0)
                        {
                            won = true;
                            break;
                        }
                        currentCol--;
                        break;
                    case 'R':
                        if (currentCol == cols - 1)
                        {
                            won = true;
                            break;
                        }
                        currentCol++;
                        break;
                }

                if (matrix[currentRow, currentCol] == 'B' && !won)
                {
                    dead = true;
                }
                else if (!won && !dead)
                {
                    matrix[currentRow, currentCol] = 'P';
                }

                Queue<int> rowQueue = new Queue<int>();
                Queue<int> colQueue = new Queue<int>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            rowQueue.Enqueue(row);
                            colQueue.Enqueue(col);
                        }
                    }
                }

                while (rowQueue.Count > 0)
                {
                    Spread(rowQueue.Dequeue(), colQueue.Dequeue());
                }





            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            if (dead)
            {
                Console.WriteLine($"dead: {currentRow} {currentCol}");
            }
            else
            {
                Console.WriteLine($"won: {currentRow} {currentCol}");
            }



            void SpreadTo(int row, int col)
            {
                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    return;
                }



                if (matrix[row, col] == 'P')
                {
                    dead = true;
                }

                matrix[row, col] = 'B';


            }

            void Spread(int row, int col)
            {
                SpreadTo(row, col - 1);
                SpreadTo(row, col + 1);
                SpreadTo(row - 1, col);
                SpreadTo(row + 1, col);
            }
        }
    }
}
