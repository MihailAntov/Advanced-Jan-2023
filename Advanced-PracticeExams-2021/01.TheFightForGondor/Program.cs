using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> wave = new Stack<int>();


            for(int i = 1; i <= waves; i++)
            {
                wave = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }



                while(wave.Count > 0 && plates.Count > 0)
                {
                    int orc = wave.Pop();
                    int plate = plates.Dequeue();

                    if (plate > orc)
                    {
                        plates.Enqueue(plate - orc);

                        for (int j = 0; j < plates.Count - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else if (orc > plate)
                    {
                        wave.Push(orc - plate);

                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }

            }

            if(wave.Count != 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }


            
            if(wave.Count!= 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");
            }
            else
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }


        }
    }
}
