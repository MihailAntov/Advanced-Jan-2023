using System;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];
            for(int i = 0; i < n; i++)
            {
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}" +
                //    " {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}" +
                //    " {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                
                int speed = int.Parse(inputArgs[1]);
                int power = int.Parse(inputArgs[2]);
                Engine engine = new Engine(speed, power);


                int weight = int.Parse(inputArgs[3]);
                string type = inputArgs[4];
                Cargo cargo = new Cargo(type, weight);

                Tire[] tires = new Tire[4];
                for(int j = 0; j < 4; j++)
                {
                    
                    double pressure = double.Parse(inputArgs[5 + (2 * j)]);
                    int age = int.Parse(inputArgs[6 + (2 * j)]);
                    tires[j] = new Tire(age, pressure);
                }
                cars[i] = new Car(model, engine, cargo, tires);
            }

            string command = Console.ReadLine();

            if(command == "fragile")
            {
                foreach (Car car in cars
                    .Where(n => n.Cargo.Type == "fragile"
                           && n.Tires.Any(n => n.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (Car car in cars
                                    .Where(n => n.Cargo.Type == "flammable"
                                           && n.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}