using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Dish
    {
        public double Cost { get; }
        public String Name { get; }
        private readonly List<Ingredient> Recipe = new List<Ingredient>();

        public Dish(String name, double cost)
        {
            if (cost <= 0)
            {
                throw new ArgumentException("Price of the dish must be higher than zero.");
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Dish must have a name.");
            }

            Name = name;
            Cost = cost;
        }

        public void IngredientsAdd(List<Ingredient> i)
        {
            Recipe.AddRange(i);
        }

        public void IngredientsAdd(Ingredient i)
        {
            Recipe.Add(i);
        }

        public void RemoveFromRecipe(string name)
        {
            Recipe.Remove(Recipe.Find(item => item.Name == name));
        }

        public string GetRecipe()
        {
            string str = $"The main ingredients of the {Name} are: ";
            foreach (var i in Recipe)
            {
                str += $"{i.Name}, ";
            }

            str = str.Remove(str.Length - 2);
            str += ".";
            return str;
        }
    }
}