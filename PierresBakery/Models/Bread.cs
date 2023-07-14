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

        public int hasOrigin(string origin)
        {
            bool has = Array.Exists(Origins, e => e == origin);
            return has ? Array.IndexOf(Origins, origin) : -1;
        }

        public string getOrigin(int i)
        {
            return char.ToUpper(Origins[i][0]) + Origins[i].Substring(1);
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
        private static string[] origins = { "german", "italian" };

        public SourdoughBread() : base("sourdough", origins, 7, 2) {}
    }
}