using System;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] map = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;
            for(int row = 0; row < size; row++)
            {
                string rowArgs = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    map[row, col] = rowArgs[col];
                    if (map[row,col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                }
            }

            string input = String.Empty;
            int flowers = 0;
            bool hasBonus = false;
            bool lost = false;
            while(input != "End")
            {
                
                
                if(!hasBonus)
                {
                    input = Console.ReadLine();   
                }
                hasBonus = false;
                map[currentRow, currentCol] = '.';
                switch (input)
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


                if(currentRow<0 || currentRow >= size || currentCol <0 ||currentCol >= size)
                {
                    lost = true;
                    EndGame();
                    return;
                }


                switch(map[currentRow,currentCol])
                {
                    case 'f':
                        flowers++;
                        break;
                    case 'O':
                        hasBonus = true;
                        break;
                }
                map[currentRow, currentCol] = 'B';
                
            }
            if(input == "End")
            {
                EndGame();
            }

            void EndGame()
            {
                if(lost)
                {
                    Console.WriteLine("The bee got lost!");
                }

                if(flowers >=5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
                }

                for(int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(map[row,col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        
    }
}
