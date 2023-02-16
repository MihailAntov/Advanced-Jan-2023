using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    internal class Race
    {
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Racer racer)
        {
            if(Count == Capacity)
            {
                return;
            }

            data.Add(racer);
        }

        public bool Remove(string name)
        {
            Racer racer = GetRacer(name);
            return data.Remove(racer);
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(n => n.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(n => n.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(n => n.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Racers participating at {Name}:");
            foreach(Racer racer in data)
            {
                str.AppendLine(racer.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
