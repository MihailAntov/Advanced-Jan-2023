using System;
namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            int bRow = 0;
            int bCol = 0;
            int wRow = 0;
            int wCol = 0;
            string coordinates = string.Empty;
            

            for(int row = 0; row < 8; row++)
            {
                string rowArgs = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = rowArgs[col];
                    if(board[row, col] == 'w')
                    {
                        wRow = row;
                        wCol = col;
                    }

                    if (board[row, col] == 'b')
                    {
                        bRow = row;
                        bCol = col;
                    }
                }
            }

            while(true)
            {
                board[wRow, wCol] = '-';
                if (wCol > 0 && board[wRow-1,wCol-1] == 'b')
                {
                    board[wRow - 1, wCol - 1] = 'w';
                    wRow--;
                    wCol--;
                    coordinates = $"{(char)(97 + wCol)}{8 - wRow}";
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    return;
                }
                if (wCol < 7 && board[wRow - 1, wCol + 1] == 'b')
                {
                    board[wRow - 1, wCol + 1] = 'w';
                    wRow--;
                    wCol++;
                    coordinates = $"{(char)(97 + wCol)}{8 - wRow}";
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    return;
                }
                else
                {
                    wRow--;
                    board[wRow, wCol] = 'w';

                    if(wRow == 0)
                    {
                        coordinates = $"{(char)(97 + wCol)}{8 - wRow}";
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                        return;
                    }
                }



                board[bRow, bCol] = '-';
                if (bCol > 0 && board[bRow + 1, bCol - 1] == 'w')
                {
                    board[bRow + 1, bCol - 1] = 'b';
                    bRow++;
                    bCol--;
                    coordinates = $"{(char)(97 + bCol)}{8 - bRow}";

                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    return;
                }
                if (bCol <7  && board[bRow + 1, bCol + 1] == 'w')
                {
                    board[bRow + 1, bCol + 1] = 'b';
                    bRow++;
                    bCol++;
                    coordinates = $"{(char)(97 + bCol)}{8 - bRow}";
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    return;
                }
                else
                {
                    bRow++;
                    board[bRow, bCol] = 'b';
                    if(bRow == 7)
                    {
                        coordinates = $"{(char)(97 + bCol)}{8 - bRow}";
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                        return;
                    }
                }

            }
        }
    }
}



