using System;
using System.Linq;

namespace _6.TargetPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(n=>int.Parse(n))
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();

            int[] shotArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int impactRow = shotArgs[0];
            int impactCol = shotArgs[1];
            int radius = shotArgs[2];

            char[,] matrix = new char[rows, cols];
            int goingLeft = -1;
            int counter = 0;
            for(int row= rows-1; row >=0; row--)
            {
                goingLeft *= -1;

                if(goingLeft == 1)
                {
                    for(int col = cols-1; col >=0; col--)
                    {
                        
                        matrix[row, col] = snake[counter % snake.Length];
                        counter++;
                    }
                }
                else
                {
                    for(int col = 0; col < cols; col++)
                    {
                        
                        matrix[row, col] = snake[counter % snake.Length];
                        counter++;

                    }
                }

            }


            

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(CompareDistance(row, col, impactRow, impactCol) <= (double)radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }

            }

          

            for (int row = rows-1; row >= 1; row--)
            {
                for(int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        for(int i = row-1; i >= 0; i--)
                        {
                            if (matrix[i, col] != ' ')
                            {
                                matrix[row, col] = matrix[i, col];
                                matrix[i, col] = ' ';
                                break;

                            }
                        }
                    }
                }
            }


            static double CompareDistance(int rowA, int colA, int rowB, int colB)
            {
                int firstSide = Math.Abs(rowA - rowB);
                int secondSide = Math.Abs(colA - colB);
                double result = Math.Sqrt((Math.Pow((double) firstSide,2) + Math.Pow((double) secondSide, 2)));
                return result;
            }




            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
