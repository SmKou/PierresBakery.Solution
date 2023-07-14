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

    public class CustardPastry : Pastry 
    {
        private static string[] origins = { "french", "portuguese", "japanese" };

        public CustardPastry() : base("custard", origins, 3, 6) {} 
    }

    public class MacaroonPastry : Pastry
    {
        private static string[] origins = { "french", "filipino" };

        public MacaroonPastry() : base("macaroon", origins, 1, 8) {}
    }

    public class StrudelPastry : Pastry
    {
        private static string[] origins = { "austrian", "turkish", "hungarian" };

        public StrudelPastry() : base("strudel", origins, 5, 3) { }
    }
}