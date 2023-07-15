using System;

namespace PierresBakery.Models
{
    public class Bread : MenuItem
    {
        public Bread(string type) : this(type, 5, 2) {}

        public Bread(string type, int cost, int deal) : base("bread", type, cost, deal) { }
    }

    public class RyeBread : Bread
    {
        public RyeBread() : base("ryebread", 8, 2) {}
    }

    public class FlatBread : Bread
    {
        public FlatBread() : base("flatbread", 6, 4) {}
    }

    public class SourdoughBread : Bread
    {
        public SourdoughBread() : base("sourdough", 7, 2) {}
    }
}