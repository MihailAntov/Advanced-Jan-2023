using System;
using System.Collections.Generic;
using System.Linq;


string input = Console.ReadLine();
Stack<char> stack = new();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(' || input[i] == '{' || input[i] == '[')
    {
        stack.Push(input[i]);
    }
    else if (input[i] == ')')
    {
        if (stack.Peek() == '(')
        {
            stack.Pop();
            continue;
        }
        else
        {
            break;
        }
    }
    else if (input[i] == ']')
    {
        if (stack.Peek() == '[')
        {
            stack.Pop();
            continue;
        }
        else
        {
            break;
        }
    }
    else if (input[i] == '}')
    {
        if (stack.Peek() == '{')
        {
            stack.Pop();
            continue;
        }
        else
        {
            break;
        }
    }
}
if (stack.Any())
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}




