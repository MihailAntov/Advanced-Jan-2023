using System;
using System.Collections.Generic;

namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            for(int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                int power = int.Parse(inputArgs[1]);

                engines.Add(model,new Engine(model, power));

                if(inputArgs.Length == 3)
                {
                    bool isInt = true;
                    foreach(char c in inputArgs[2])
                    {
                        if(!char.IsDigit(c))
                        {
                            isInt = false;
                            break;
                        }
                    }

                    if(isInt)
                    {
                        engines[model].Displacement = int.Parse(inputArgs[2]);
                    }
                    else
                    {
                        engines[model].Efficiency = inputArgs[2];
                    }
                }
                else if (inputArgs.Length == 4)
                {
                    engines[model].Displacement = int.Parse(inputArgs[2]);
                    engines[model].Efficiency = inputArgs[3];
                }
            }

            int m = int.Parse(Console.ReadLine());
            Car[] cars = new Car[m];
            for (int i = 0; i < m; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                Engine engine = engines[inputArgs[1]];
                cars[i] = new Car(model, engine);

                if (inputArgs.Length == 3)
                {
                    bool isInt = true;
                    foreach (char c in inputArgs[2])
                    {
                        if (!char.IsDigit(c))
                        {
                            isInt = false;
                            break;
                        }
                    }

                    if (isInt)
                    {
                        cars[i].Weight = int.Parse(inputArgs[2]);
                    }
                    else
                    {
                        cars[i].Color = inputArgs[2];
                    }
                }
                else if (inputArgs.Length == 4)
                {
                    cars[i].Weight = int.Parse(inputArgs[2]);
                    cars[i].Color = inputArgs[3];
                }
            }

            foreach(Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}