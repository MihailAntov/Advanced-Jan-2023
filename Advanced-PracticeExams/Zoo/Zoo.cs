using System.Collections.Generic;
using System.Linq;
namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public IReadOnlyCollection<Animal> Animals => animals;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal (Animal animal)
        {
            if(animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            if(string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if(animal.Diet!= "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            return animals.RemoveAll(n => n.Species == species);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return animals.Where(n => n.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.FirstOrDefault(n => n.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = animals
                .Where(n => n.Length >= minimumLength && n.Length <= maximumLength)
                .Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
