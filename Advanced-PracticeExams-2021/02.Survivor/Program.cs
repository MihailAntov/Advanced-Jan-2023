using System;
using System.Linq;
namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];

            for(int row = 0; row < rows; row++)
            {
                char[] rowArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beach[row] = new char[rowArgs.Length];
                for(int col = 0; col < rowArgs.Length; col++)
                {
                    beach[row][col] = rowArgs[col];
                }
            }

            int playerTokens = 0;
            int enemyTokens = 0;

            string input;

            while((input = Console.ReadLine())!= "Gong")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                if (!IsValid(row, col))
                {
                    continue;
                }

                switch (command)
                {
                    case "Find":
                        if (beach[row][col] == 'T')
                        {
                            playerTokens++;
                            beach[row][col] = '-';
                        }
                        break;
                    case "Opponent":

                        string direction = cmdArgs[3];
                        Collect(row, col, direction);
                        break;
                }
            }
            Print();

            
            void Print()
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < beach[row].Length; col++)
                    {
                        Console.Write($"{beach[row][col]} ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"Collected tokens: {playerTokens}");
                Console.WriteLine($"Opponent's tokens: {enemyTokens}");
            }

            bool IsValid(int row, int col)
            {
                if(row < 0 || row >= rows)
                {
                    return false;
                }

                if(col < 0 || col >= beach[row].Length)
                {
                    return false;
                }
                return true;
            }

            void Collect(int row, int col, string direction)
            {
                if (beach[row][col] == 'T')
                {
                    enemyTokens++;
                    beach[row][col] = '-';
                }

                for(int i = 0; i < 3; i++)
                {
                    switch(direction)
                    {
                        case "up":
                            row--;
                            break;
                        case "down":
                            row++;
                            break;
                        case "left":
                            col--;
                            break;
                        case "right":
                            col++;
                            break;
                    }

                    if(IsValid(row,col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            enemyTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
            }
        }
    }
}
