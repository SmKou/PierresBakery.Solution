using System;

namespace PierresBakery.Models
{
    public class MenuItem
    {
        public string ItemName { get; }
        public int Cost { get; set; }
        public int DealAmount { get; set; }
        public string Type { get; }
        public string[] Origins { get; }

        public MenuItem(string itemName, string type, string[] origins)
        {
            ItemName = itemName;
            Type = type;
            Origins = origins;
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

        public static Bread makeBread(string type)
        {
            switch (type)
            {
                case "rye":
                case "ryebread":
                    return new RyeBread();
                case "flat":
                case "flatbread":
                    return new FlatBread();
                case "sour":
                case "sourdough":
                    return new SourdoughBread();
                default:
                    string[] possible_origins = { "french", "italian", "portuguese", "american" };
                    int i = new Random().Next(0, 4);
                    return new Bread("special", new string[] { possible_origins[i] });
            }
        }

        public static Pastry makePastry(string type)
        {
            switch (type)
            {
                case "custard":
                    return new CustardPastry();
                case "macaron":
                case "macaroon":
                    return new MacaroonPastry();
                case "strudel":
                    return new StrudelPastry();
                default:
                    string[] possible_origins = { "filipino", "austrian", "portuguese", "french" };
                    int i = new Random().Next(0, 4);
                    return new Pastry("special", new string[] { possible_origins[i] });
            }
        }

        public int GetSubtotal(int n)
        {
            int free_items = n / (DealAmount + 1);
            return (n - free_items) * Cost;
        }
    }
}