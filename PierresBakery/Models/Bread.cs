using System;

namespace PierresBakery.Models
{
    public class Bread : MenuItem
    {
        public Bread(string type, string[] origins) : this(type, origins, 5, 2) {}

        public Bread(string type, string[] origins, int cost, int deal) : base("bread", type, origins) {
            this.Cost = cost;
            this.DealAmount = deal;
        }
    }

    public class RyeBread : Bread
    {
        private static string[] origins = { "icelandic", "finnish" };

        public RyeBread() : base("ryebread", origins, 8, 2) {}
    }

    public class FlatBread : Bread
    {
        private static string[] origins = { "middle eastern", "italian" };

        public FlatBread() : base("flatbread", origins, 6, 4) {}
    }

    public class SourdoughBread : Bread
    {
        private static string[] origins = { "german", "italian", "american" };

        public SourdoughBread() : base("sourdough", origins, 7, 2) {}
    }
}