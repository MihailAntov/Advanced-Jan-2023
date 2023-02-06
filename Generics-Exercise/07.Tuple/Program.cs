using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] inputArgs = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //string name = string.Join(" ", inputArgs[0..^1]);
            //string address = inputArgs[^1];
            //Tuple<string, string> tuple1 = new Tuple<string, string>(name, address);

            //Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");

            //inputArgs = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //name = string.Join(" ", inputArgs[0]);
            //int beerCapcity = int.Parse(inputArgs[1]);
            //Tuple<string, int> tuple2 = new Tuple<string, int>(name, beerCapcity);

            //Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

            //inputArgs = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //int num1 = int.Parse(inputArgs[0]);
            //double num2 = double.Parse(inputArgs[1]);

            //Tuple<int, double> tuple3 = new Tuple<int, double>(num1, num2);

            //Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");

            string[] inputArgs = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = string.Join(" ", inputArgs[0..2]);
            string address = inputArgs[2];
            string town = String.Join(" ",inputArgs[3..^0]);

            ThreeUpple<string, string,string> tuple1 = new ThreeUpple<string, string,string>(name, address,town);

            Console.WriteLine(tuple1);

            inputArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            name = string.Join(" ", inputArgs[0]);
            int beerCapcity = int.Parse(inputArgs[1]);
            bool status = inputArgs[2] == "drunk" ? true : false;
            ThreeUpple<string, int,bool> tuple2 = new ThreeUpple<string, int, bool>(name, beerCapcity,status);

            Console.WriteLine(tuple2);

            inputArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string holder = inputArgs[0];
            double balance = double.Parse(inputArgs[1]);
            string bank = inputArgs[2];

            ThreeUpple<string, double,string> tuple3 = new ThreeUpple<string, double,string>(holder, balance,bank);

            Console.WriteLine(tuple3);




        }
    }
}