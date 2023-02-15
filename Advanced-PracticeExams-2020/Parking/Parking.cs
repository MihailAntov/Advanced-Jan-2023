using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;   
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if(data.Count == Capacity)
            {
                return;
            }

            data.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(data.FirstOrDefault(n => n.Manufacturer == manufacturer && n.Model == model));
        }

        public Car GetLatestCar()
        {
            if(data.Count == 0)
            {
                return null;
            }

            return data.OrderByDescending(n => n.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(n => n.Manufacturer == manufacturer && n.Model == model);
        }

        public int Count { get { return data.Count; } }

        public string GetStatistics()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"The cars are parked in {Type}:");
            foreach(Car car in data)
            {
                str.AppendLine(car.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
