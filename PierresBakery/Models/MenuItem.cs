using System;

namespace PierresBakery.Models
{
    public abstract class MenuItem
    {
        public string Product { get; }
        public string Option { get; }
        public string Variety { get; set; }
        public int Quantity { get; set; }

        public MenuItem(string product, string option, string variety, int qty)
        {
            Product = product;
            Option = option;
            Variety = variety;
            Quantity = qty;
        }

        public string Item()
        {
            string item = char.ToUpper(Option[0]) + Option.Substring(1);
            item += $" - {Variety}";

            int blankSpace = 40 - item.Length;
            for (int i = 0; i < blankSpace; i++)
            {
                item += " ";
            }

            if (Quantity > 0)
            {
                item += Quantity.ToString();
                item += "  $" + Total();
            }
            else
                item += "0  $" + Menu.Deal(Option);

            return item; 
        }

        public abstract int Total();
    }
}