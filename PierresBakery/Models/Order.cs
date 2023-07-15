using System.Collections.Generic;
using System.Linq;

namespace PierresBakery.Models
{
    public class Order
    {
        private Dictionary<string, MenuItem> item_list;

        public Order() 
        {
            item_list = new Dictionary<string, MenuItem>();
        }

        public bool HasItem(string item)
        {
            return item_list.ContainsKey(item);
        }

        public void AddItem(string item, MenuItem details)
        {
            item_list.Add(item, details);
        }

        public bool DeleteItem(string item)
        {
            if (item_list.ContainsKey(item))
            {
                item_list.Remove(item);
                return true;
            }
            return false;
        }

        public bool ChangeQty(string item, int qty)
        {
            if (item_list.ContainsKey(item)) {
                item_list[item].Quantity = qty;
                return true;
            }
            return false;
        }

        public string[] GetItems()
        {
            string[] items = new string[item_list.Count];
            item_list.Keys.CopyTo(items, 0);
            return items;
        }

        public string[] GetOrder()
        {
            List<string> order = new List<string>();
            string divider = "";
            for (int i = 0; i < 46; i++)
                divider += "-";
            order.Add(divider);
            string[] items = GetItems();
            for (int i = 0; i < items.Length; i++)
                order.Add($"{i}. " + item_list[items[i]].GetItem());
            order.Add(divider);
            string total = "Total";
            for (int i = 0; i < 35; i++)
                total += " ";
            total += "$" + GetTotal();
            order.Add(divider);
            return order.ToArray();
        }

        private int GetTotal()
        {
            List<int> subtotals = new List<int>();
            foreach (MenuItem item in item_list.Values)
                subtotals.Add(item.GetSubtotal());
            return subtotals.Sum();
        }
    }
}