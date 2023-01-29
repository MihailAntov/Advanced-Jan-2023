using System;
using System.Linq;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            string date1 = String.Join("-", (Console.ReadLine()
                .Split(" ")));
            string date2 = String.Join("-", (Console.ReadLine()
                .Split(" ")));
            DateModifier modifier = new DateModifier();
            

            Console.WriteLine(modifier.CalculateDifference(date1,date2));
        }
    }
}