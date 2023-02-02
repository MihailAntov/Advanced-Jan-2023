using System;
using System.Linq;

namespace _5.RubiksMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => byte.Parse(n))
                .ToArray();

            byte rows = dimensions[0];
            byte cols = dimensions[1];
            long[,] cube = new long[rows, cols];
            long[] order = new long[rows * cols];
            long counter = 0;
            for (byte row = 0; row < rows; row++)
            {
                for (byte col = 0; col < cols; col++)
                {
                    cube[row, col] = ++counter;
                    order[counter - 1] = counter;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                byte rowOrCol = byte.Parse(inputArgs[0]);
                string command = inputArgs[1];
                long times = long.Parse(inputArgs[2]);
                long buffer;


                switch (command)
                {
                    case "up":
                        for (int time = 0; time < times % rows; time++)
                        {
                            buffer = cube[0, rowOrCol];
                            for (int j = 0; j < rows - 1; j++)
                            {
                                cube[j, rowOrCol] = cube[j + 1, rowOrCol];
                            }
                            cube[rows - 1, rowOrCol] = buffer;
                        }
                        break;

                    case "down":
                        for (int time = 0; time < times % rows; time++)
                        {
                            buffer = cube[rows - 1, rowOrCol];
                            for (int j = rows - 1; j >= 1; j--)
                            {
                                cube[j, rowOrCol] = cube[j - 1, rowOrCol];
                            }
                            cube[0, rowOrCol] = buffer;
                        }
                        break;

                    case "left":
                        for (int time = 0; time < times % cols; time++)
                        {
                            buffer = cube[rowOrCol, 0];
                            for (int j = 0; j < cols - 1; j++)
                            {
                                cube[rowOrCol, j] = cube[rowOrCol, j + 1];
                            }
                            cube[rowOrCol, rows - 1] = buffer;
                        }
                        break;

                    case "right":
                        for (int time = 0; time < times % cols; time++)
                        {
                            buffer = cube[rowOrCol, cols - 1];
                            for (int j = cols - 1; j >= 1; j--)
                            {
                                cube[rowOrCol, j] = cube[rowOrCol, j - 1];
                            }
                            cube[rowOrCol, 0] = buffer;
                        }
                        break;
                }

                //Print(cube);




            }

            CheckCube(cube, order);


            static void CheckCube(long[,] cube, long[] order)
            {
                long counter = 0;
                for (byte row = 0; row < cube.GetLength(0); row++)
                {
                    for (byte col = 0; col < cube.GetLength(1); col++)
                    {
                        CheckCell(row, col, cube, order, ++counter);
                    }
                }
            }

            static void CheckCell(byte row, byte col, long[,] cube, long[] order, long counter)
            {
                //if (cube[row, col] != col + row * (cube.GetLength(1)) + 1)
                //{
                //    //mismatch


                if (order[counter - 1] != cube[row, col])
                {
                    for (int targetRow = 0; targetRow < cube.GetLength(0); targetRow++)
                    {
                        for (int targetCol = 0; targetCol < cube.GetLength(1); targetCol++)
                        {
                            if (cube[targetRow, targetCol] == counter)
                            {
                                Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                                long buffer = cube[row, col];
                                cube[row, col] = cube[targetRow, targetCol];
                                cube[targetRow, targetCol] = buffer;
                                return;
                            }
                        }
                    }
                }

                else
                {
                    Console.WriteLine("No swap required");
                }
            }

        }
    }
}
