using System;

namespace PierresBakery.Models
{
    public class MenuItem
    {

        public string Product { get; }
        public string Option { get; }
        public string Variety { get; set; } = "";
        public int Quantity { get; set; } = 0;

        public MenuItem(string product, string option, int cost, int deal)
        {
            Product = product;
            Option = option;
            Cost = cost;
            Deal = deal;
        }

        public string GetItem()
        {
            string item = char.ToUpper(Option[0]) + Option.Substring(1);
            if (Variety != "")
                item += $" - {Variety}";
            int blankSpace = 40 - item.Length;
            for (int i = 0; i < blankSpace; i++)
            {
                item += " ";
            }
            if (Quantity > 0)
            {
                item += Quantity.ToString();
                item += "  $" + GetSubtotal();
            }
            else
                item += "0  $" + Deal;
            return item; 
        }

        public int GetSubtotal()
        {
            int free = Quantity / (Deal + 1);
            return (Quantity - free) * Cost;
        }
    }
}