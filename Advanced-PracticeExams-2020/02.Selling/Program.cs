using System;

namespace _02.Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];
            int currentRow = 0;
            int currentCol = 0;
            int money = 0;
            for(int row = 0; row < size; row++)
            {
                string rowArgs = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = rowArgs[col];
                    if(bakery[row, col] == 'S')
                    {
                        currentCol = col;
                        currentRow = row;
                    }
                }
            }

            while(money < 50)
            {
                string command = Console.ReadLine();
                bakery[currentRow, currentCol] = '-';
                
                switch(command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if(currentRow< 0 || currentCol < 0 || currentRow >= size || currentCol >= size)
                {
                    break;
                }

                switch (bakery[currentRow,currentCol])
                {
                    case '-':
                        break;
                    case 'O':
                        bakery[currentRow, currentCol] = '-';
                        for(int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (bakery[row,col] == 'O')
                                {
                                    currentRow = row;
                                    currentCol = col;
                                }
                            }
                        }
                        break;
                    default:
                        int value = int.Parse(bakery[currentRow, currentCol].ToString());
                        money += value;
                        break;

                }
                bakery[currentRow, currentCol] = 'S';
            }

            if(money >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {money}");
            for(int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(bakery[row,col]);
                }
                Console.WriteLine();
            }
        }

        
    }
}
