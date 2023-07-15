using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Order
    {
        private Dictionary<string, MenuItem> item_list;

        public Order() 
        {
            item_list = new Dictionary<string, MenuItem>();
        }

        public bool AddItem(string name, MenuItem item, int qty)
        {
            if (qty <= 0)
                return false;
            item.Quantity = qty;
            item_list.Add(name, item);
            return true;
        }

        public bool DeleteItem(string name)
        {
            if (item_list.ContainsKey(name))
            {
                item_list.Remove(name);
                return true;
            }
            return false;
        }

        public bool ChangeQty(string name, int qty)
        {
            if (item_list.ContainsKey(name)) {
                item_list[name].Quantity = qty;
                return true;
            }
            return false;
        }

        public string[] GetOrder()
        {
            item_list<string> order = new List<string>();
            foreach (var item in item_list)
            {
                Order.Add($"{item.Key} : ${item.Value.Quantity}  ${item.Value.GetSubtotal()}");
            }
            return order.ToArray();
        }
    }
}