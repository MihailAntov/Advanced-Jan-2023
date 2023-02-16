using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        public Airfield(string name, int capacity, double landingStrip)
        {
            
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public IReadOnlyCollection<Drone> Drones { get { return drones; } }

        public int Count { get { return drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if(string.IsNullOrEmpty(drone.Name)
                || string.IsNullOrEmpty(drone.Brand) 
                || drone.Range <5 
                || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if(Count == Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone droneToRemove = drones.Find(n => n.Name == name);
            return drones.Remove(droneToRemove);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return drones.RemoveAll(n => n.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly =  drones.Find(n => n.Name == name);
            if(droneToFly != null)
            {
                droneToFly.Available = false;
            }

            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = drones.FindAll(n => n.Range >= range);
            foreach (Drone drone in dronesToFly)
            {
                FlyDrone(drone.Name);
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Drones available at {Name}:");
            foreach(Drone drone in drones.FindAll(n=>n.Available))
            {
                str.AppendLine(drone.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
