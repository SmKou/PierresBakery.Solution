using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Order
    {
        private static string[] breads = { "ryebread", "flatbread", "sourdough" };
        private static string[] pastries = { "custard", "macaroon", "strudel" };
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

        public static string GetOptions(string product)
        {
            string[] product_list = { "" };
            switch (product)
            {
                case "bread":
                    product_list = breads;
                    break;
                case "pastry":
                    product_list = pastries;
                    break;
                default:
                    product_list = new string[breads.Length + pastries.Length];
                    breads.CopyTo(product_list, 0);
                    pastries.CopyToo(product_list, breads.Length);
                    break;
            }

            string list = "";
            for (int i = 0; i < product_list.Length; i++) {
                if (i == product_list.Length - 1)
                    list += " and ";
                list += product_list[i];
                if (i != product_list.Length - 1)
                    list += ", ";
            }
            return list;
        }

        public static string GetVarieties(string product, string type)
        {
            string list = "";
        }

        private static string[] GetList

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