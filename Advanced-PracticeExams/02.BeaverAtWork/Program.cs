using System;
using System.Linq;
using System.Collections.Generic;
namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int currentRow = 0;
            int currentCol = 0;
            bool swimming = false;

            int stickCount = 0;
            char[,] pond = new char[size, size];
            List<char> sticks = new List<char>();
            for (int row = 0; row < size; row++)
            {
                char[] rowArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = rowArgs[col];

                    if (pond[row, col] == 'B')
                    {
                        currentCol = col;
                        currentRow = row;
                    }
                    else if (char.IsLower(pond[row, col]))
                    {
                        stickCount++;
                    }
                }
            }

            string command = String.Empty;
            while (stickCount > 0)
            {
                if (command.ToLower() == "end")
                {
                    break;
                }

               


                

                if (!swimming)
                {
                    command = Console.ReadLine();
                    pond[currentRow, currentCol] = '-';

                    switch (command)
                    {
                        case "up":
                            if (currentRow == 0)
                            {
                                if (sticks.Count > 0)
                                {
                                    sticks.RemoveAt(sticks.Count - 1);
                                }
                            }
                            else
                            {
                                currentRow--;
                            }
                            break;
                        case "down":
                            if (currentRow == size - 1)
                            {
                                if (sticks.Count > 0)
                                {
                                    sticks.RemoveAt(sticks.Count - 1);
                                }
                            }
                            else
                            {
                                currentRow++;
                            }
                            break;
                        case "left":
                            if (currentCol == 0)
                            {
                                if (sticks.Count > 0)
                                {
                                    sticks.RemoveAt(sticks.Count - 1);
                                }
                            }
                            else
                            {
                                currentCol--;
                            }

                            break;
                        case "right":
                            if (currentCol == size - 1)
                            {
                                if (sticks.Count > 0)
                                {
                                    sticks.RemoveAt(sticks.Count - 1);
                                }
                            }
                            else
                            {
                                currentCol++;
                            }
                            break;
                    }
                }


                if (swimming)
                {
                    swimming = false;
                }

                switch (pond[currentRow, currentCol])
                {
                    case '-':
                        break;
                    case 'F':
                        pond[currentRow, currentCol] = '-';
                        swimming = true;
                        switch (command)
                        {
                            case "up":
                                if (currentRow != 0)
                                {
                                    currentRow = 0;
                                }
                                else
                                {
                                    currentRow = size - 1;
                                    command = "down";
                                }


                                break;
                            case "down":
                                if (currentRow != size - 1)
                                {
                                    currentRow = size - 1;
                                }
                                else
                                {
                                    currentRow = 0;
                                    command = "up";
                                }
                                break;
                            case "left":
                                if (currentCol != 0)
                                {
                                    currentCol = 0;
                                    command = "right";
                                }
                                else
                                {
                                    currentCol = size - 1;
                                }
                                break;
                            case "right":
                                if (currentCol != size - 1)
                                {
                                    currentCol = size - 1;
                                }
                                else
                                {

                                    currentCol = 0;
                                    command = "left";
                                }
                                break;
                        }
                        break;
                    default:
                        if (char.IsLower(pond[currentRow,currentCol]))
                        {
                            stickCount--;
                            sticks.Add(pond[currentRow, currentCol]);
                            pond[currentRow, currentCol] = '-';
                        }
                        
                        break;
                }

                //Print();
                //Console.WriteLine(stickCount);
            }

            if (stickCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {sticks.Count} wood branches: {string.Join(", ", sticks)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {stickCount} branches left.");
            }
            Print();

            void Print()
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (row == currentRow && col == currentCol)
                        {
                            Console.Write("B ");
                        }
                        else
                        {
                            Console.Write(pond[row, col] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}





