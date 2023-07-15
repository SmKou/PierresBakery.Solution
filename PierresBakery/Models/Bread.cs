using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Bread : MenuItem
    {
        public static Dictionary<string, int> _costs = new Dictionary<string, int> {
            {"special", 5},
            {"ryebread", 8},
            {"flatbread", 6},
            {"sourdough", 7}
        };
        public static Dictionary<string, int> _deals = new Dictionary<string, int>
        {
            {"special", 2},
            {"ryebread", 2},
            {"flatbread", 4},
            {"sourdough", 2}
        };

        public Bread() : this("special") { }

        public Bread(string option) : this(option, _costs[option], _deals[option]) {}

        public Bread(string option, int cost, int deal) : base("bread", option, cost, deal) { }

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