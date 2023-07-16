using System.Collections.Generic;
using System.Linq;

namespace PierresBakery.Models
{
    public class Order
    {
        private Dictionary<string, MenuItem> _items = new Dictionary<string, MenuItem>();

        public string[] Items()
        {
            string[] items = new string[_items.Count];
            _items.Keys.CopyTo(items, 0);
            return items;
        }

        public bool HasItem(string item)
        {
            return _items.ContainsKey(item);
        }

        public void AddItem(MenuItem item)
        {
            string key = $"{item.Option}-{item.Variety}";
            if (_items.ContainsKey(key))
                _items[key].Quantity = item.Quantity;
            else
                _items.Add(key, item);
        }

        public bool DeleteItem(string key)
        {
            if (_items.ContainsKey(key))
            {
                _items.Remove(key);
                return true;
            }
            return false;
        }

        public bool ChangeQty(string key, int qty)
        {
            if (_items.ContainsKey(key)) {
                _items[key].Quantity = qty;
                return true;
            }
            return false;
        }

        public string[] Receipt()
        {
            List<string> order = new List<string>();

            string divider = "";
            for (int i = 0; i < 50; i++)
                divider += "-";
            order.Add(divider);

            string[] keys = Items();
            for (int i = 0; i < keys.Length; i++)
                order.Add($"{i + 1}. " + _items[keys[i]].Item());

            order.Add(divider);
            string total = "Total";
            for (int i = 0; i < 41; i++)
                total += " ";
            total += "$" + Total();
            order.Add(total);
            order.Add(divider);

            return order.ToArray();
        }

        private int Total()
        {
            List<int> subtotals = new List<int>();
            foreach (MenuItem item in _items.Values)
                subtotals.Add(item.Total());
            return subtotals.Sum();
        }
    }
}