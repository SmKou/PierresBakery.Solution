using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Pastry : MenuItem
    {
        public Pastry() : this("pastry") {}

        public Pastry(string option) : base("pastry", option, options[option][0], options[option][1])
    }
}