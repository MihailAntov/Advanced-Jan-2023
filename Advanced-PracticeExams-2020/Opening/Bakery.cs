using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();    
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Employee employee)
        {
            if(Count == Capacity)
            {
                return;
            }
            data.Add(employee);
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(n=>n.Name == name);
            return data.Remove(employee);
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(n => n.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(n => n.Name == name);
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Employees working at Bakery {bakeryName}:");
            foreach(Employee employee in data)
            {
                str.AppendLine(employee.ToString());
            }

            return str.ToString().TrimEnd();
        }
    }
}
