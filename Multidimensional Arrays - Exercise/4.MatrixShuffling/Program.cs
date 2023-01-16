using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = dimensions[0];
int cols = dimensions[1];
string[,] matrix = new string[rows, cols];
for (int row = 0; row < rows; row++)
{
    string[] rowInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowInfo[col];
    }
}

string input;

while((input = Console.ReadLine())!= "END")
{
    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    if (cmdArgs.Length != 5 ||  cmdArgs[0] != "swap")
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    int row1 = int.Parse(cmdArgs[1]);
    int col1 = int.Parse(cmdArgs[2]);
    int row2 = int.Parse(cmdArgs[3]);
    int col2 = int.Parse(cmdArgs[4]);
    

    if(row1 <0 || row1 >= rows
        || col1 < 0 || col1 >= cols 
        || row2<0 || row2 >= rows 
        || col2<0 || col2>= cols)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    string buffer = matrix[row1, col1];
    matrix[row1, col1] = matrix[row2, col2];
    matrix[row2, col2] = buffer;

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }
        Console.WriteLine();
    }
}

