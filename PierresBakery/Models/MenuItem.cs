using System;

namespace PierresBakery.Models
{
    public class MenuItem
    {
        public string ItemName { get; }
        public string ItemOption { get; }
        public string ItemVariety { get; set; }
        public int Cost { get; }
        public int DealAmount { get; }
        public int Quantity { get; set; } = 0;

        public MenuItem(string itemName, string option, int cost, int deal_amt)
        {
            ItemName = itemName;
            ItemOption = option;
            Cost = cost;
            DealAmount = deal_amt;
        }

        public string GetItem()
        {
            string item = char.ToUpper(ItemOption[0]) + ItemOption.Substring(1);
            item += $" - {ItemVariety}";
            int blank_space = 40 - item.Length;
            for (int i = 0; i < blank_space; i++)
            {
                item += " ";
            }
            item += Quantity.ToString();
            item += "  $" + GetSubtotal();
            return item; 
        }

        public int GetSubtotal()
        {
            int free_items = Quantity / (DealAmount + 1);
            return (Quantity - free_items) * Cost;
        }
    }
}