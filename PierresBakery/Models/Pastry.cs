using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Pastry : MenuItem
    {
        public Pastry(string option, string variety, int qty) : base("pastry", option, variety, qty) { }

        public override int Total()
        {
            int free = Quantity / (Menu.Deal(Option) + 1);
            return (Quantity - free) * Menu.Deal(Option);
        }
    }
}