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
            string[] possible_origins = { "filipino", "austrian", "portuguese", "french" };
            int i = new Random().Next(0, 4);
            return new Pastry("special", new string[] { possible_origins[i]});
        }

        public int GetSubtotal(int n)
        {
            int free_items = n / (DealAmount + 1);
            return (n - free_items) * Cost;
        }
    }
}