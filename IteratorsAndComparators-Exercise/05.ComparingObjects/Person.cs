using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if(Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            if(Age.CompareTo(other.Age) != 0)
            {
                return Age.CompareTo(other.Age);
            }

            return Town.CompareTo(other.Town);
        }

        public static void CompareToAll(Person thisPerson, IEnumerable<Person> people)
        {
            int matches = 0;
            int notMatches = 0;

            foreach (Person person in people)
            {
                if(thisPerson.CompareTo(person) == 0 )
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }
            
            if(matches > 1)
            {
                Console.WriteLine($"{matches} {notMatches} {people.Count()}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
            
        }

        
    }
}
