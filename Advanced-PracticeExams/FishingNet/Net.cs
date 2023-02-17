using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> _fish;
        public Net(string material, int capacity)
        {
            
            Material = material;
            Capacity = capacity;
            _fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Fish> Fish { get { return _fish; } }
        public int Count { get { return _fish.Count; } }

        public string AddFish (Fish fish)
        {
            if(string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }

            if(Count == Capacity)
            {
                return "Fishing net is full.";
            }

            _fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish (double weight)
        {
            Fish fishToRemove = _fish.FirstOrDefault(n => n.Weight == weight);
            return _fish.Remove(fishToRemove);
        }

        public Fish GetFish(string fishType)
        {
            return _fish.FirstOrDefault(n => n.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return _fish.OrderByDescending(n => n.Length)
                .FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Into the {Material}:");
            foreach(Fish fish in _fish.OrderByDescending(n=>n.Length))
            {
                str.AppendLine(fish.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
