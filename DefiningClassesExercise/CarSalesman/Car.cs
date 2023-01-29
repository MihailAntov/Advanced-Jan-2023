using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
       
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        
        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString();
            string color = Color == null ? "n/a" : Color;
            string displacement = Engine.Displacement == 0 ? "n/a" : Engine.Displacement.ToString();
            string efficiency = Engine.Efficiency == null ? "n/a" : Engine.Efficiency;

            StringBuilder str = new StringBuilder();
            str.AppendLine($"{Model}:");
            str.AppendLine($"  {Engine.Model}:");
            str.AppendLine($"    Power: {Engine.Power}");
            str.AppendLine($"    Displacement: {displacement}");
            str.AppendLine($"    Efficiency: {efficiency}");
            str.AppendLine($"  Weight: {weight}");
            str.Append($"  Color: {color}");

            return str.ToString();
        }
    }
}
