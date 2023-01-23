using System;
using System.Collections;
using System.Collections.Generic;

char[] input = Console.ReadLine().ToCharArray();
Stack<char> stack = new();
Queue<char> queue = new();

foreach (var character in input)
{
	switch (character)
	{
		case '{':
		case '(':
		case '[':
			queue.Enqueue(character);
			break;

		case '}':
		case ')':
		case ']':
			stack.Push(character);
			break;
	}
}
bool isBalanced = true;
if (queue.Count != stack.Count)
{
	isBalanced = false;
}
for (int i = 0; i < queue.Count; i++)
{
	char queueElement = queue.Dequeue();
	char stackElement = stack.Pop();

	if (queueElement == '(' && stackElement != ')' ||
		queueElement == '[' && stackElement != ']' ||
		queueElement == '{' && stackElement != '}')
	{
		isBalanced = false;
	}
}
if (isBalanced)
{
	Console.WriteLine("YES");
}
else
{
	Console.WriteLine("NO");
}