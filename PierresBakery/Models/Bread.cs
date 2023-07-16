using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Bread : MenuItem
    {
        public Bread(string option, string variety, int qty) : base("bread", option, variety, qty) { }

        public override int Total()
        {
            int free = Quantity / (Menu.Deal(Option) + 1);
            return (Quantity - free) * Menu.Cost(Option);
        }
    }
}