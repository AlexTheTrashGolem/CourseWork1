using System;
using System.Collections.Generic;
using System.Collections;

namespace Restaurant
{
    public class MenuEntry : IEnumerable
    {
        public Dish EntryType { get; private set; }
        public List<double> _weight;
        public MenuEntry(Dish dish, double weight)
        {
            EntryType = dish;
            _weight = new List<double>{weight};
        }
        public MenuEntry(Dish dish, List<double> weight)
        {
            EntryType = dish;
            _weight = weight;
        }
        public MenuEntry(String name, double cost, double weight)
        {
            EntryType = new Dish(name,cost);
            _weight[0] = weight;
        }
        public double Price(int i)
        {
            return Math.Round(_weight[i]*EntryType.Cost, 2);
        }
        public String Name()
        {
            return EntryType.Name;
        }
        public IEnumerator GetEnumerator()
        {
            return _weight.GetEnumerator();
        }
    }
}