using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {



            int n = int.Parse(Console.ReadLine());


            Queue<Pump> circle = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                circle.Enqueue(new Pump(tokens[0], tokens[1]));
            }

            for (int i = 0; i < circle.Count; i++)
            {
                Queue<Pump> tempCircle = new Queue<Pump>(circle);
                for (int j = 0; j < i; j++)
                {
                    tempCircle.Enqueue(tempCircle.Dequeue());
                }

                int fuel = tempCircle.Peek().Petrol;

                while (tempCircle.Count > 1)
                {
                    if (fuel >= tempCircle.Peek().Distance)
                    {
                        fuel -= tempCircle.Dequeue().Distance;
                        fuel += tempCircle.Peek().Petrol;
                    }
                    else
                    {

                        break;
                    }
                }

                if (tempCircle.Count == 1)
                {
                    Console.WriteLine(i);
                    break;
                }
            }



        }



        public class Pump
        {
            public Pump(int petrol, int distance)
            {
                Petrol = petrol;
                Distance = distance;
            }

            public int Petrol { get; set; }
            public int Distance { get; set; }
        }
    }
}

