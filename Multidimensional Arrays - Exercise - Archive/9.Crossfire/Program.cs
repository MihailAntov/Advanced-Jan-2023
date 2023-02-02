using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Crossfire
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
            List<List<string>> matrix = new List<List<string>>();
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<string>());
                for (int col = 0; col < cols; col++)
                {

                    counter++;
                    matrix[row].Add(counter.ToString());
                }
            }


            string input;

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] shotArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int shotRow = shotArgs[0];
                int shotCol = shotArgs[1];
                int radius = shotArgs[2];

                

                int startRow = shotRow - radius;
                int endRow = shotRow + radius;
                int startCol = shotCol - radius;
                int endCol = shotCol + radius;
                
                

                for(int row = 0; row < matrix.Count; row++)
                {
                    //if(row == shotRow)
                    //{
                    //    int startCol = shotCol - radius;
                    //    int endCol = shotCol + radius;
                    //    for (int col = 0; col < matrix[row].Count; col++)
                    //    {
                    //        if (row >= startRow && row <= endRow && col >= startCol && col <= endCol)
                    //        {
                    //            matrix[row][col] = "";
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (row >= startRow && row <= endRow && shotCol > 0 && shotCol <= matrix[row].Count-1)
                    //    {
                    //        matrix[row][shotCol] = "";
                    //    }
                    //}


                    for(int col = 0; col < matrix[row].Count; col++)
                    {
                        if((row >= startRow && row <= endRow  && col == shotCol )|| (row == shotRow && col >= startCol && col <= endCol))
                        {
                            matrix[row][col] = "";
                        }
                    }
                    
                }

               

                for (int i = 0; i < matrix.Count; i++)
                {
                    matrix[i].RemoveAll(n => n == "");
                }
                matrix.RemoveAll(n => n.Count == 0);


            }

            
            for (int row = 0; row < matrix.Count; row++)
            {
                List<string> rowResult = new List<string>();
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    rowResult.Add(matrix[row][col]);

                }
                Console.WriteLine(String.Join(" ", rowResult));
            }
        }
    }
}
