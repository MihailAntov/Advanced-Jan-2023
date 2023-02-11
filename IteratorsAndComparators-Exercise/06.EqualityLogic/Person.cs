using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public Person(string name, int age)
        {
            Name = name.ToLower();
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

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

            return 0;
        }

        public bool Equals(Person other)
        {
            return this.CompareTo(other) == 0;
        }



        public override int GetHashCode()
        {
            int result = 0;
            for(int i = 0; i< Name.Length; i++)
            {
                if(i%2 == 0)
                {
                    result += Name[i];
                }
                else
                {
                    result *= Name[i];
                }
            }

            int currentAge = Age;
            while(currentAge != 0)
            {
                result *= currentAge % 10;
                currentAge /= 10;
            }

            return result;
        }
    }
}
