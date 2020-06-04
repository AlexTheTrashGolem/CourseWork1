using System;
using System.Collections.Generic;
using System.Collections;

namespace Restaurant
{
     public class Order : IEnumerable, IPriceList
     {
          private List<MenuEntry> DishList { get; set; }

          public Order(MenuEntry entry, PriceList target)
          {
               DishList = new List<MenuEntry>();
               AddDish(entry, target);
          }
          public void AddDish(MenuEntry dish, double weight, PriceList target)
          {
               if (target.ContainsDish(dish))
               {
                    if (!dish._weight.Contains(weight))
                    {
                         throw new ArgumentException("There is no such portion for this dish.");
                    }
                    foreach (var i in DishList)
                    {
                         if (i.EntryType == dish.EntryType)
                         {
                              i._weight.Add(weight);
                              return;
                         }
                    }
                    DishList.Add(new MenuEntry(dish.EntryType, weight));
               }
               else
               {
                    throw new ArgumentException("There is no such dish in this Menu");
               }
          }
          public void AddDish(MenuEntry dish, PriceList target)
          {
               if (target.ContainsDish(dish))
               {
                    foreach (var i in DishList)
                    {
                         if (i.EntryType == dish.EntryType)
                         {
                              i._weight.AddRange(i._weight);
                              return;
                         }
                    }
                    DishList.Add(dish);
               }
               else
               {
                    throw new ArgumentException("There is no such dish in this Menu");
               }
          }
          public void RemoveDish(string name)
          {
               DishList.Remove(DishList.Find(item => item.Name() == name));
          }
          private double GetPrice()
          {
               double sum = 0;
               foreach (MenuEntry i in DishList)
               {
                    for (int j = 0; j < i._weight.Count; j++)
                    {
                         sum += i.Price(j);
                    }
               }

               return sum;
          }
          public string Format()
          {
               string str = "Your order:\n";
               foreach (var i in DishList)
               {
                    str += $"{i.EntryType.Name} \n";
                    for (int j=0; j<i._weight.Count; j++)
                    {
                         str += $"{i._weight[j]}gr. - {i.Price(j)} uah    ";
                    }

                    str += "\n";
               }

               str += $"Total: {GetPrice()} uah\n";
               return str;
          }
          public IEnumerator GetEnumerator()
          {
               return DishList.GetEnumerator();
          }
     }
}