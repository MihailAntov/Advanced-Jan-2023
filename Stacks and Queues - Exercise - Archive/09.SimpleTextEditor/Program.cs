using System;
using System.Collections.Generic;
using System.Linq;


namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;

            Stack<Command> undoCommands = new Stack<Command>();
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = inputArgs[0];
                switch (command)
                {
                    case "1":
                        text += inputArgs[1];
                        undoCommands.Push(new EraseCommand(inputArgs[1].Length));
                        break;
                    case "2":
                        string textToBeRemoved = text.Substring(text.Length - int.Parse(inputArgs[1]));
                        text = text[..^int.Parse(inputArgs[1])];
                        undoCommands.Push(new AppendCommand(textToBeRemoved));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(inputArgs[1]) - 1]);
                        break;
                    case "4":
                        text = undoCommands.Pop().Execute(text);
                        //undoes the last command
                        break;
                }
            }
        }
        public abstract class Command
        {
            public int Type { get; set; }
            public abstract string Execute(string text);

        }

        public class AppendCommand : Command
        {
            public AppendCommand(string textToAppend)
            {
                TextToAppend = textToAppend;
                Type = 1;
            }

            public string TextToAppend { get; set; }
            public override string Execute(string text)
            {
                text += TextToAppend;
                return text;
            }

        }

        public class EraseCommand : Command
        {
            public EraseCommand(int eraseCount)
            {
                EraseCount = eraseCount;
                Type = 2;
            }
            public int EraseCount { get; set; }
            public override string Execute(string text)
            {
                text = text[..^EraseCount];
                return text;
            }
        }
    }
}

