using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int wreaths = 0;
            int stored = 0;

            while(lilies.Count > 0 && roses.Count > 0)
            {
                int currentRoses = roses.Dequeue();
                int currentLilies = lilies.Pop();

                while(currentLilies + currentRoses > 15)
                {
                    currentLilies -= 2;
                }

                if(currentLilies+currentRoses ==15)
                {
                    wreaths++;
                }
                else
                {
                    stored += currentLilies + currentRoses;
                }
            }

            wreaths += stored / 15;

            if(wreaths == 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }

            
        }
    }
}
