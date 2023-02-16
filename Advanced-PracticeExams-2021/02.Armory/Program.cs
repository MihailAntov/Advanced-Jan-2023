using System;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int currentRow = 0;
            int currentCol = 0;
            char[,] map = new char[size, size];

            for(int row = 0; row < size; row++)
            {
                string rowArgs = Console.ReadLine();
                for(int col = 0; col < size; col++)
                {
                    map[row, col] = rowArgs[col];
                    if (map[row,col]=='A')
                    {
                        currentCol = col;
                        currentRow = row;
                        map[row,col] = '-';
                    }
                }
            }
            int gold = 0;
            while(gold < 65)
            {
                string command = Console.ReadLine();
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

                if(currentRow < 0 || currentRow >= size || currentCol < 0 || currentCol >= size)
                {
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {gold} gold coins.");
                    Print();
                    return;
                }

                switch(map[currentRow,currentCol])
                {
                    case '-':
                        break;
                    case 'M':
                        map[currentRow, currentCol] = '-';
                        for(int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (map[row,col] == 'M')
                                {
                                    currentRow = row;
                                    currentCol = col;
                                    map[row, col] = '-';
                                    break;
                                }
                            }
                        }
                        break;
                        default:
                        int value = int.Parse(map[currentRow, currentCol].ToString());
                        gold += value;
                        map[currentRow, currentCol] = '-';
                        break;
                }

                
            }

            Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {gold} gold coins.");
            Print();


            void Print()
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if(row == currentRow && col == currentCol)
                        {
                            Console.Write('A');
                        }
                        else
                        {
                            Console.Write(map[row,col]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
