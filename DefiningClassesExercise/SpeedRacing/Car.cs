using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int kilometers)
        {
            if(kilometers*FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            FuelAmount -= FuelConsumptionPerKilometer * kilometers;
            TravelledDistance += kilometers;
            
        }
        public void Print()
        {
            Console.WriteLine($"{Model} {FuelAmount:f2} {TravelledDistance}");
        }

    }
}
