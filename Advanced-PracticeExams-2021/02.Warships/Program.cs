using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] attacks = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);
            char[,] map = new char[size, size];
            Queue<Move> moves = new Queue<Move>();

            for (int i = 0; i < attacks.Length; i++)
            {
                int[] moveArgs = attacks[i]
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                moves.Enqueue(new Move(moveArgs[0], moveArgs[1]));
            }

            int p1ships = 0;
            int p2ships = 0;
            int totalSunk = 0;

            for (int row = 0; row < size; row++)
            {
                char[] rowArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    map[row, col] = rowArgs[col];
                    if (map[row, col] == '<')
                    {
                        p1ships++;
                    }
                    else if (map[row, col] == '>')
                    {
                        p2ships++;
                    }
                }
            }

            while (moves.Count > 0)
            {
                Move move = moves.Dequeue();
                if (move.Row < 0 || move.Row >= size || move.Col < 0 || move.Col >= size)
                {
                    continue;
                }

                switch (map[move.Row, move.Col])
                {
                    case '<':
                        p1ships--;
                        totalSunk++;
                        map[move.Row, move.Col] = 'X';
                        break;

                    case '>':
                        p2ships--;
                        totalSunk++;
                        map[move.Row, move.Col] = 'X';
                        break;

                    case '#':
                        Detonate(move.Row, move.Col);
                        break;
                }

            
                if(p1ships == 0 || p2ships == 0)
                {
                    break;
                }
            }
            if(p1ships != 0 && p2ships != 0)
            {
                Console.WriteLine($"It's a draw! Player One has {p1ships} ships left. Player Two has {p2ships} ships left.");
            }
            else if (p1ships > 0)
            {
                Console.WriteLine($"Player One has won the game! {totalSunk} ships have been sunk in the battle.");
            }
            else if(p2ships > 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalSunk} ships have been sunk in the battle.");
            }

            
            




            void Detonate(int detonateRow, int detonateCol)
            {
                for(int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (row >= detonateRow - 1
                            && row <= detonateRow + 1
                            && col >= detonateCol - 1
                            && col <= detonateCol + 1)
                        {
                            switch (map[row, col])
                            {
                                case '<':
                                    p1ships--;
                                    totalSunk++;
                                    map[row, col] = 'X';
                                    break;

                                case '>':
                                    p2ships--;
                                    totalSunk++;
                                    map[row, col] = 'X';
                                    break;
                            }
                        }
                    }
                }
            }


        }
    }

    public class Move
    {
        public Move(int row, int col)
        {
            Row = row;
            Col = col;

        }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
