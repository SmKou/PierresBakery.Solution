using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Pastry : MenuItem
    {
        private static Dictionary<string, int> _costs = new Dictionary<string, int> {
            {"special", 2},
            {"custard", 3},
            {"macaroon", 1},
            {"strudel", 5}
        };
        private static Dictionary<string, int> _deals = new Dictionary<string, int> {
            {"special", 3},
            {"custard", 6},
            {"macaroon", 8},
            {"strudel", 3}
        };

        public Pastry() : this("special") {}

        public Pastry(string option) : this(option, _costs[option], _deals[option]) { }

        public Pastry(string option, int cost, int deal) : base("pastry", option, cost, deal) { }

        public static int ItemCost(string option)
        {
            if (!_costs.ContainsKey(option))
                return 0;
            return _costs[option];
        }

        public static int ItemDeal(string option)
        {
            if (!_deals.ContainsKey(option))
                return 0;
            return _deals[option];
        }
    }
}