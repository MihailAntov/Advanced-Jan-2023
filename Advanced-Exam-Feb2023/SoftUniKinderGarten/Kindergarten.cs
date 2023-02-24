using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            registry = new List<Child>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get { return registry; } }

        public int ChildrenCount { get { return registry.Count; } }
        public bool AddChild (Child child)
        {
            if(ChildrenCount == Capacity)
            {
                return false;
            }

            registry.Add(child);
            return true;

        }

        public bool RemoveChild(string childFullName)
        {
            Child childToRemove = GetChild(childFullName);
            return registry.Remove(childToRemove);
        }

        public Child GetChild(string childFullName)
        {
            return registry.FirstOrDefault(n => $"{n.FirstName} {n.LastName}" == childFullName);
        }

        public string RegistryReport()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Registered children in {Name}:");
            foreach(Child child in Registry
                .OrderByDescending(n=>n.Age)
                .ThenBy(n=>n.LastName)
                .ThenBy(n=>n.FirstName))
            {
                str.AppendLine(child.ToString());
            }

            return str.ToString().TrimEnd();

        }


    }
}
