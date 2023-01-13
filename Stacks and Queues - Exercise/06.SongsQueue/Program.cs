using System;
using System.Collections.Generic;
using System.Linq;

Queue<string> songs = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries));

while(songs.Any())
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if(input.Length > 1)
    {
        string newSong = String.Join(" ", input[1..]);
        if(songs.Contains(newSong))
        {
            Console.WriteLine($"{newSong} is already contained!");
            continue;
        }
        songs.Enqueue(newSong);
    }
    else if (input[0] == "Play")
    {
        songs.Dequeue();
    }
    else if (input[0] == "Show")
    {
        Console.WriteLine(String.Join(", ",songs));
    }
    
}

Console.WriteLine("No more songs!");