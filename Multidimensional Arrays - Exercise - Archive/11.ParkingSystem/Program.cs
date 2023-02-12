using System;
using System.Linq;

namespace _11.ParkingSystem
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

            int[,] parkingLot = new int[rows, cols];

            

            string input;

            while((input = Console.ReadLine())!= "stop")
            {
                int[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryrow = inputArgs[0];
                int targetRow = inputArgs[1];
                int targetCol = inputArgs[2];

                int moveCounter = 1;
                bool found = false;
                moveCounter += Math.Abs(entryrow - targetRow);

                if (parkingLot[targetRow, targetCol] != 0)
                {
                    //taken
                    
                    for(int i = 1; i < cols-1; i++)
                    {
                        if (targetCol - i > 0 && parkingLot[targetRow, targetCol - i] == 0)
                        {
                            moveCounter += targetCol - i;
                            parkingLot[targetRow, targetCol - i] = 1;
                            found = true;
                            break;
                        }
                        else if (targetCol + i < cols && parkingLot[targetRow,targetCol +i] == 0)
                        {
                            moveCounter += targetCol + i;
                            parkingLot[targetRow, targetCol + i] = 1;
                            found = true;
                            break;
                        }
                    }

                    if(!found)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                    
                }
                else
                {
                    parkingLot[targetRow, targetCol] = 1;
                    moveCounter += targetCol;
                    found = true;
                }

                if(found)
                {
                    Console.WriteLine(moveCounter);
                }
                
            }
        }
    }
}
