using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    internal class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Make: {Make}");
            str.AppendLine($"Model: {Model}");
            str.AppendLine($"HorsePower: {HorsePower}");
            str.Append($"RegistrationNumber: {RegistrationNumber}");
            return str.ToString();

        }
    }
}
