using System.Collections.Generic;
using System;
using Restaurant;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Oil"),
                new Ingredient("Vegetables"),
                new Ingredient("Some meat"),
                new Ingredient("Spices"),
            };
            
            Dish soup = new Dish("Soup", 0.04);
            soup.IngredientsAdd(ingredients[1]);
            soup.IngredientsAdd(ingredients[2]);
            Dish salad = new Dish("Salad", 0.02);
            salad.IngredientsAdd(ingredients[0]);
            salad.IngredientsAdd(ingredients[1]);
            Dish steak = new Dish("Steak", 0.07);
            Console.WriteLine(soup.GetRecipe());
            Console.WriteLine(salad.GetRecipe());
            
            var soupPortions = new List<double>
                {200, 400, 600};
            var steakPortions = new List<double>
                {300, 500};
            var entry1 = new MenuEntry(salad, 500);
            var entry2 = new MenuEntry(soup, soupPortions);
            var entry3 = new MenuEntry(steak, steakPortions);
            var myPriceList = new PriceList(entry1);
            myPriceList.AddDish(entry2);
            myPriceList.AddDish(entry3);
            Console.WriteLine(myPriceList.Format());
            
            myPriceList.RemoveDish("Salad");
            Console.WriteLine(myPriceList.Format());
            
            var myOrder = new Order(entry3, myPriceList);
            myOrder.AddDish(entry2, 400, myPriceList);
            Console.WriteLine(myOrder.Format());
            
            myOrder.AddDish(entry2, 200, myPriceList);
            myOrder.RemoveDish("Steak");
            Console.WriteLine(myOrder.Format());
        }
    }
}