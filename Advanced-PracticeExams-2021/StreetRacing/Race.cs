using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }

        public IReadOnlyCollection<Car> Participants { get { return participants; } }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count { get { return Participants.Count; } }
        public void Add(Car car)
        {
            if(Count == Capacity)
            {
                return;
            }

            if(participants.Any(n=>n.LicensePlate == car.LicensePlate))
            {
                return;
            }

            if(car.HorsePower > MaxHorsePower)
            {
                return;
            }

            participants.Add(car);
        }

        public bool Remove(string licensePlate)
        {
            Car carToRemove = FindParticipant(licensePlate);
            return participants.Remove(carToRemove);
        }

        public Car FindParticipant(string licensePlate)
        {
            return participants.FirstOrDefault(n => n.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return participants.OrderByDescending(n => n.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach(Car car in participants)
            {
                str.AppendLine(car.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
