using System;
using System.Collections.Generic;
using System.Linq;


string input = Console.ReadLine();
Stack<char> stack = new();
bool balanced = true;
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(' || input[i] == '{' || input[i] == '[')
    {
        stack.Push(input[i]);
    }
    else if (input[i] == ')')
    {
        if (stack.Count == 0)
        {
            balanced = false;
            break;
        }

        if (stack.Peek() == '(')
        {
            stack.Pop();
            continue;
        }
        else
        {
            balanced = false;
            break;
        }
    }
    else if (input[i] == ']')
    {
        if (stack.Count == 0)
        {
            balanced = false;
            break;
        }

        if (stack.Peek() == '[')
        {
            stack.Pop();
            continue;
        }
        else
        {
            balanced = false;
            break;
        }
    }
    else if (input[i] == '}')
    {
        if (stack.Count == 0)
        {
            balanced = false;
            break;
        }

        if (stack.Peek() == '{')
        {
            stack.Pop();
            continue;
        }
        else
        {
            balanced = false;
            break;
        }
    }
}
if (!balanced)
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}




