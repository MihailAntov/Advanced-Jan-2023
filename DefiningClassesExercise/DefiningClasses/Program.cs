using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                family.People.Add(new Person(name, age));

            }

            foreach(Person person in family.People
                .Where(n=>n.Age > 30)
                .OrderBy(n=>n.Name))
            {
                person.Print();
            }

        }
    }
}