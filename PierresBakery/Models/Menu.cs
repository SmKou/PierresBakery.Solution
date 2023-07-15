using System;

namespace PierresBakery.Models
{
    public class Menu
    {
        public static Dictionary<string, string[]> options = new Dictionary<string, string[]> 
        {
            { "bread", new string[] { "ryebread", "flatbread", "sourdough", "special" }},
            { "pastry", new string[] { "custard", "macaroon", "strudel", "special" }}
        };
        public static Dictionary<string, string[]> specials = new Dictionary<string, string[]>
        {
            { "bread", new string[] { "french", "italian", "portuguese", "american" }},
            { "pastry", new string[] { "filipino", "austrian", "portuguese", "french" }}
        };
        public static Dictionary<string, string[]> varieties = new Dictionary<string, string[]>
        {
            { "ryebread", new string[] { "icelandic", "finnish" }}
            { "flatbread", new string[] { "middle eastern", "italian" }}
            { "sourdough", new string[] { "german", "italian", "american" }},
            { "custard", new string[] { "french", "portuguese", "japanese" }},
            { "macaroon", new string[] { "french", "filipino" }},
            { "strudel", new string[] { "austrian", "turkish", "hungarian" }},
        };

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
                    return new Bread("special");
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
                    return new Pastry("special");
            }
        }

        public static bool HasOption(string item)
        {
            return options.ContainsKey(item);
        }

        public static bool HasVariety(string type)
        {
            return varieties.ContainsKey(type);
        }

        public static string GetOptions(string item)
        {
            if (!hasOption(item))
                return new string[] { "" };
            return stringify(options[item]);
        }

        public static string GetVarieties(string type)
        {
            if (!hasVariety(type))
                return new string[] { "" };
            return stringify(varieties[type]);
        }

        private static string stringify(string[] items)
        {
            string list = "";
            for (int i = 0; i < items.Length; i++)
            {
                list += items[i];
                if (i != items.Length - 1)
                    list += ", ";
            }
        }

        public static string GetSpecial(string item)
        {
            if (!specials.ContainsKey(item))
                return new string[] { "" };
            int s = (new Random()).Next(0, specials[item].Length);
            return specials[item][s];
        }
    }
}