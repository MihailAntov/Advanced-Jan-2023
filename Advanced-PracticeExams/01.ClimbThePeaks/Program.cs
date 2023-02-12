using System;
using System.Collections.Generic;
using System.Linq;



Stack<int> food = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> stamina = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

List<Peak> peaksList = new List<Peak>
{
    {new Peak("Vihren",80) },
    {new Peak("Kutelo",90) },
    {new Peak("Banski Suhodol",100) },
    {new Peak("Polezhan",60) },
    {new Peak("Kamenitza",70) }

};
Queue<Peak> peaks = new Queue<Peak>(peaksList);
List<Peak> conqueredPeaks = new List<Peak>();

while(stamina.Any() && food.Any())
{
    int currentStrength = food.Pop() + stamina.Dequeue();
    if(currentStrength >= peaks.Peek().Difficulty)
    {
        conqueredPeaks.Add(peaks.Dequeue());
    }

    if(!peaks.Any())
    {
        break;
    }
}

if(peaks.Any())
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}

if(conqueredPeaks.Any())
{
    Console.WriteLine("Conquered peaks:");
    foreach (Peak peak in conqueredPeaks)
    {
        Console.WriteLine(peak.Name);
    }
}





class Peak
{
    public Peak(string name, int difficulty)
    {
        Name = name;
        Difficulty = difficulty;    
    }
    public string Name { get; set; }
    public int Difficulty { get; set; }
}