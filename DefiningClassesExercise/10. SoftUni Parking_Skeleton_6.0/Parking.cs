using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    internal class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count
        {
            get { return cars.Count; }
        }
        public List<Car> Cars { get { return cars; }}

        public string AddCar(Car car)
        {
            //"Car with that registration number, already exists!"
            //    "Parking is full!"
            //    "Successfully added new car {Make} {RegistrationNumber}"
            if(cars.Any(n=>n.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
                
            }

            if(cars.Count == capacity)
            {
                return "Parking is full!";
                
            }

            cars.Add(car);
            return$"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if(!cars.Select(n=>n.RegistrationNumber).Contains(registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            for(int i = 0; i < cars.Count; i++)
            {
                if (cars[i].RegistrationNumber == registrationNumber)
                {
                    cars.RemoveAt(i);
                    return $"Successfully removed {registrationNumber}";
                    
                }
            }
            return null;
            
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(n => n.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<String> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                if(cars.Select(n=>n.RegistrationNumber).Contains(registrationNumber))
                {
                    RemoveCar(registrationNumber);
                }
            }
        }
    }
}
