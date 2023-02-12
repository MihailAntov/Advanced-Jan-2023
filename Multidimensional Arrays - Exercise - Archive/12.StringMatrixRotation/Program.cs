using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.StringMatrixRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string input;
            List<string> words = new List<string>();
            while((input = Console.ReadLine()) != "END")
            {
                words.Add(input);
            }

            int rows = words.Count;
            int cols = words.OrderByDescending(x => x.Count()).FirstOrDefault().Count();
            char[,] matrix = new char[rows, cols];

            for(int row = 0; row < rows; row++)
            {
                string word = words[row];
                for (int col = 0; col < cols; col++)
                {
                    if(col < word.Length)
                    {
                        matrix[row, col] = word[col];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            int degrees = Math.Abs(int.Parse(command[7..^1]) % 360);
            int rotations = degrees / 90;
            
            for(int i = 0; i < rotations; i++)
            {
                matrix = Rotate(matrix);
            }

            for(int row = 0; row < matrix.GetLength(0); row ++)
            {
                StringBuilder str = new StringBuilder();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                     str.Append(matrix[row, col]);
                    
                }
                Console.WriteLine(str.ToString());
            }
            




        }

        public static char[,] Rotate(char[,] matrix)
        {
            char[,] newMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for(int row = 0; row < matrix.GetLength(0); row++ )
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    newMatrix[col, matrix.GetLength(0)-1-row] = matrix[row, col];
                }
            }


            return newMatrix;
        }
    }
}
