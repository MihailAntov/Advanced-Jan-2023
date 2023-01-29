using System;
using System.Collections.Generic;
namespace SpeedRacing
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            for(int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumptionPerKm = double.Parse(inputArgs[2]);
                cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKm));
            }

            string input;

            while((input = Console.ReadLine())!= "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputArgs[1];
                int km = int.Parse(inputArgs[2]);

                cars[model].Drive(km);
            }

            foreach(KeyValuePair<string, Car> car in cars)
            {
                car.Value.Print();
            }
        }
    }
}