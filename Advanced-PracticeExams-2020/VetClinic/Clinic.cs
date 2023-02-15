using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if(data.Count== Capacity)
            {
                return;
            }

            data.Add(pet);
        }

        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(n => n.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(n => n.Name == name && n.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(n => n.Age).FirstOrDefault();
        }

        public int Count { get { return data.Count; } }

        public string GetStatistics()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("The clinic has the following patients:");
            foreach(Pet pet in data)
            {
                str.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return str.ToString().TrimEnd();
        }
    }
}
