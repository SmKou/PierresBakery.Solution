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
        public string[] Options { get; }
        public int Quantity { get; set; } = 0;

        public MenuItem(string itemName, string type, string[] origins, string[] options)
        {
            ItemName = itemName;
            Type = type;
            Origins = origins;
        }

        public bool HasOrigin(string origin)
        {
            return Array.Exists(Origins, e => e == origin);
        }

        public string GetOrigin(int i)
        {
            return char.ToUpper(Origins[i][0]) + Origins[i].Substring(1);
        }

        public static Bread MakeBread(string type)
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

        public static Pastry MakePastry(string type)
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