using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }
        public void Add(Ski ski)
        {
            if(Count == Capacity)
            {
                return;
            }

            data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = GetSki(manufacturer, model);
            return data.Remove(skiToRemove);
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(n => n.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(n => n.Manufacturer == manufacturer && n.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"The skis stored in {Name}:");
            foreach(Ski ski in data)
            {
                str.AppendLine(ski.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
