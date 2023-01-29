using System;
using System.Collections.Generic;
using System.Linq;
namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string pokemonName = inputArgs[1];
                string element = inputArgs[2];
                int health = int.Parse(inputArgs[3]);

                if(!trainers.ContainsKey(name))
                {
                    trainers.Add(name, new Trainer(name));
                }

                trainers[name].Pokemons.Add(new Pokemon(pokemonName, element, health));
            }

            while((input = Console.ReadLine())!= "End")
            {
                foreach(KeyValuePair<string, Trainer> trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(n => n.Element == input))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        trainer.Value.Pokemons =
                            trainer.Value.Pokemons.Where(n => n.Health > 10)
                            .Select(n => new Pokemon(n.Name, n.Element, n.Health - 10))
                            .ToList();
                    }
                }
            }

            foreach(Trainer trainer in trainers.Values
                .OrderByDescending(n=>n.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}