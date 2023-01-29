using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            while((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] theseTires = new Tire[4];
                for(int i = 0; i < 4; i++)
                {
                    theseTires[i] = new Tire
                        (
                            int.Parse(inputArgs[2 * i]),
                            double.Parse(inputArgs[2 * i + 1])
                        );
                }
                tires.Add(theseTires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(
                    int.Parse(inputArgs[0]),
                    double.Parse(inputArgs[1])));
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cars.Add(new Car(
                    inputArgs[0],
                    inputArgs[1],
                    int.Parse(inputArgs[2]),
                    double.Parse(inputArgs[3]),
                    double.Parse(inputArgs[4]),
                    engines[int.Parse(inputArgs[5])],            
                    tires[int.Parse(inputArgs[6])]
                    ));
            }
            Car[] specialCars = cars.Where(n =>
            n.Year >= 2017
            && n.Engine.HorsePower > 330
            && n.Tires.Sum(n => n.Pressure) > 9
            && n.Tires.Sum(n => n.Pressure) < 10)
                .ToArray();

            foreach (Car car in specialCars)
            {
                car.Drive(20);
            }

            foreach (Car car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }

        }
    }
}