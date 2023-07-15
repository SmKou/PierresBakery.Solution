using System;

namespace PierresBakery.Models
{
    public class MenuItem
    {
        public string ItemName { get; }
        public string ItemType { get; }
        public string ItemVariant { get; set; }
        public int Cost { get; }
        public int DealAmount { get; }
        public int Quantity { get; set; } = 0;

        public MenuItem(string itemName, string type, int cost, int deal_amt)
        {
            ItemName = itemName;
            ItemType = type;
            Cost = cost;
            DealAmount = deal_amt;
        }

        public string GetItem()
        {
            string item = char.ToUpper(ItemType[0]) + ItemType.Substring(1);
            item += $" - {ItemVariant}";
            int blank_space = 80 - item.Length;
            for (int i = 0; i < blank_space; i++)
            {
                item += " ";
            }
            item += Quantity.ToString();
            return item; 
        }

        public int GetSubtotal(int n)
        {
            int free_items = n / (DealAmount + 1);
            return (n - free_items) * Cost;
        }
    }
}