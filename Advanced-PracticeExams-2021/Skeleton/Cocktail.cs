using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public  class Cocktail
    {
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return ingredients.Select(n => n.Alcohol).Sum(); } }

        public void Add(Ingredient ingredient)
        {
            if(ingredients.Any(n=>n.Name == ingredient.Name))
            {
                return;
            }

            if(Capacity == ingredients.Count)
            {
                return;
            }

            if(CurrentAlcoholLevel + ingredient.Alcohol > MaxAlcoholLevel)
            {
                return;
            }

            ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            Ingredient ingredientToRemove = FindIngredient(name);
            return ingredients.Remove(ingredientToRemove);
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(n => n.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(n => n.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach(Ingredient ingredient in ingredients)
            {
                str.AppendLine(ingredient.ToString());
            }
            return str.ToString().TrimEnd();
        }


    }
}
