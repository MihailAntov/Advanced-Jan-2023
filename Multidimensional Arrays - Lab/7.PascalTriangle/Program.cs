using System;
using System.Collections.Generic;

long n = int.Parse(Console.ReadLine());
long[][] triangle = new long[n][];


//declare triangle with the top cell being equal to 1
    triangle[0] = new long[1] { 1 };

// loop through rows , skipping the first
    for (int row = 1; row < n; row++)
    {


    //generate current current row    
    triangle[row] = new long[row + 1];

    //set first and last cell
        triangle[row][0] = 1;
        triangle[row][row] = 1;

    //go through all cells except the first and last, and set their value based on cells above
        for (int col = 1; col < row; col++)
        {
            triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
        }
    }


    //print triangle
    foreach (long[] row in triangle)
    {
        Console.WriteLine(String.Join(" ", row));
    }



