namespace PierresBakery.Models
{
    public class Pastry : MenuItem
    {
        public Pastry(string type) : this(type, 2, 3) { }

        public Pastry(string type, int cost, int deal) : base("pastry", type, cost, deal) { }
    }

    public class CustardPastry : Pastry 
    {
        public CustardPastry() : base("custard", 3, 6) {} 
    }

    public class MacaroonPastry : Pastry
    {
        public MacaroonPastry() : base("macaroon", 1, 8) {}
    }

    public class StrudelPastry : Pastry
    {
        public StrudelPastry() : base("strudel", 5, 3) { }
    }
}