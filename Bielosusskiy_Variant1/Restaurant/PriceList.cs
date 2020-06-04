using System.Collections;
using System.Collections.Generic;

namespace Restaurant
{
    public class PriceList : IEnumerable, IPriceList
    {
        private List<MenuEntry> DishList { get; set; }
        public PriceList(MenuEntry entry)
        {
            DishList = new List<MenuEntry>{entry};
        }
        public PriceList(List<MenuEntry> list)
        {
            DishList = list;
        }
        public void RemoveDish(string name)
        {
            DishList.Remove(DishList.Find(item => item.Name() == name));
        }
        public static PriceList operator +(PriceList dl, MenuEntry dish)
        {
            dl.AddDish(dish);
            return dl;
        }
        public void AddDish(MenuEntry dish)
        {
            foreach (var i in DishList)
            {
                if (i.EntryType == dish.EntryType)
                {
                    i._weight.AddRange(dish._weight);
                    return;
                }
            }
            DishList.Add(dish);
        }
        public string Format()
        {
            string str = "Menu:\n";
            foreach (var i in DishList)
            {
                str += $"{i.Name()} \n";
                for (int j = 0; j < i._weight.Count; j++)
                {
                    str += $"{i._weight[j]}gr. - {i.Price(j)} uah    ";
                }

                str += "\n";
            }

            return str;
        }
        public bool ContainsDish(MenuEntry dish)
        {
            return DishList.Contains(dish);
        }
        public IEnumerator GetEnumerator()
        {
            return DishList.GetEnumerator();
        }
    }
}