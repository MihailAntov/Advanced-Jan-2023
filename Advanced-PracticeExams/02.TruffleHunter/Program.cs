using System;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] forest = new string[size, size];


            for (int row = 0; row < size; row++)
            {
                string[] rowArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = rowArgs[col];
                }
            }

            string input;
            int blackTruffels = 0;
            int whiteTruffels = 0;
            int summerTruffels = 0;
            int boarTruffels = 0;

            while((input = Console.ReadLine())!= "Stop the hunt")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];

                if(command == "Collect")
                {
                    int collectRow = int.Parse(inputArgs[1]);
                    int collectCol = int.Parse(inputArgs[2]);

                    switch(forest[collectRow,collectCol])
                    {
                        case "B":
                            blackTruffels++;
                            forest[collectRow, collectCol] = "-";
                            break;
                        case "S":
                            summerTruffels++;
                            forest[collectRow, collectCol] = "-";
                            break;
                        case "W":
                            whiteTruffels++;
                            forest[collectRow, collectCol] = "-";
                            break;
                        default:
                            break;
                    }
                }
                else if(command == "Wild_Boar")
                {
                    int boarRow = int.Parse(inputArgs[1]);
                    int boarCol = int.Parse(inputArgs[2]);
                    string direction = inputArgs[3];

                    BoarEating(boarRow, boarCol, direction);
                    
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffels} black, {summerTruffels} summer, and {whiteTruffels} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffels} truffles.");

            for(int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(forest[row, col]+" ");
                }
                Console.WriteLine();
            }

            void BoarEating(int boarRow, int boarCol, string direction)
            {
                switch (direction)
                {
                    case "up":
                        for (int row = boarRow; row >= 0; row -= 2)
                        {
                            if (forest[row, boarCol] != "-")
                            {
                                forest[row, boarCol] = "-";
                                boarTruffels++;
                            }
                        }
                        break;
                    case "down":
                        for (int row = boarRow; row <size; row += 2)
                        {
                            if (forest[row, boarCol] != "-")
                            {
                                forest[row, boarCol] = "-";
                                boarTruffels++;
                            }
                        }

                        break;
                    case "left":
                        for (int col = boarCol; col >= 0; col -= 2)
                        {
                            if (forest[boarRow, col] != "-")
                            {
                                forest[boarRow, col] = "-";
                                boarTruffels++;
                            }
                        }

                        break;
                    case "right":
                        for (int col = boarCol; col < size; col += 2)
                        {
                            if (forest[boarRow, col] != "-")
                            {
                                forest[boarRow, col] = "-";
                                boarTruffels++;
                            }
                        }
                        break;
                }


            }
        }
        
    }
}
