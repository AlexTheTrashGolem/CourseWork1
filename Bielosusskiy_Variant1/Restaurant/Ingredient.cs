using System;

namespace Restaurant
{
    public class Ingredient
    {
        public String Name { get; }
        public Ingredient(String name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Ingredient must have a name.");
            }

            Name = name;
        }
    }
}