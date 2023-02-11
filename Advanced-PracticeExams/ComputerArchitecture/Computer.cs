using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return multiprocessor.Count; } }
        public void Add(CPU cpu)
        {
            if (Count  ==  Capacity)
            {
                return;
            }
            multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            if(GetCPU(brand) != null)
            {
                CPU cpuToBeRemoved = GetCPU(brand);
                multiprocessor.RemoveAt(multiprocessor.IndexOf(cpuToBeRemoved));
                return true;
            }
            
            return false;
        }

        public CPU MostPowerful()
        {
            return multiprocessor.MaxBy(n => n.Frequency);
        }

        public CPU GetCPU(string brand)
        {
            if (multiprocessor.Any(n => n.Brand == brand))
            {
                return multiprocessor.FirstOrDefault(n => n.Brand == brand);
            }

            return null;
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"CPUs in the Computer {Model}");
            foreach(CPU cpu in multiprocessor)
            {
                str.AppendLine(cpu.ToString());
            }


            return str.ToString().TrimEnd();
        }

        
        
    }
}
