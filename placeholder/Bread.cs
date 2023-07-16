using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Bread : MenuItem
    {
        public Bread() : this("bread") { }

        public Bread(string option) : base("bread", option, options[option][0], options[option][1])
    }
}