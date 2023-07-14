namespace PierresBakery.Models
{
    public class Pastry : MenuItem
    {
        public Pastry(string type, string[] origins) : this(type, origins, 2, 3) { }

        public Pastry(string type, string[] origins, int cost, int deal) : base("pastry", type, origins) {
            this.Cost = cost;
            this.DealAmount = deal;
        }
    }
}