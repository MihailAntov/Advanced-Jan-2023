using System;
using System.Collections.Generic;
using System.Linq;

int greenLight = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());

Queue<string> cars = new();
int carCounter = 0;
string input;

while((input = Console.ReadLine())!= "END")
{
    switch (input)
    {
        case "green":

            int currentGreenLight = greenLight;
            int currentFreeWindow = freeWindow;
            while (cars.Count > 0)
            {
                string currentCar = cars.Dequeue();
                Queue<char> car = new Queue<char>(currentCar);
                while(car.Count > 0)
                {
                    char currentElement = car.Dequeue();
                    if(currentGreenLight == 0 && currentFreeWindow == 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentElement}.");
                        return;
                    }
                    else if (currentGreenLight == 0)
                    {
                        if(currentFreeWindow == 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentElement}.");
                            return;
                        }
                        else
                        {
                            currentFreeWindow--;
                        }
                        
                    }
                    else
                    {
                        currentGreenLight--;
                    }
                }

                carCounter++;
                if(currentGreenLight == 0)
                {
                    break;
                }
                
            }


            break;
        default:
            cars.Enqueue(input);
            break;
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carCounter} total cars passed the crossroads.");

