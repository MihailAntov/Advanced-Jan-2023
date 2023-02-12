using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count { get { return renovators.Count(); } }
        public string AddRenovator (Renovator renovator)
        {
            if(NeededRenovators == renovators.Count())
            {
                return "Renovators are no more needed.";
            }

            if(renovator.Name == null || renovator.Type == null)
            {
                return "Invalid renovator's information.";
            }

            if(renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator (string name)
        {
            Renovator renovatorToRemove = renovators.FirstOrDefault(n => n.Name == name);

            return renovators.Remove(renovatorToRemove);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(n => n.Type == type);
            
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = renovators.FirstOrDefault(n => n.Name == name);
            if(renovatorToHire == null)
            {
                return null;
            }
            else
            {
                renovatorToHire.Hired = true;
                return renovatorToHire;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(n => n.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Renovators available for Project {Project}:");
            foreach(var renovator in renovators.Where(n=>n.Hired == false))
            {
                str.AppendLine(renovator.ToString());
            }

            return str.ToString().TrimEnd();
                
        }
    }
}
