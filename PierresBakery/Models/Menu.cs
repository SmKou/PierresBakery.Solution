using System;
using System.Collections.Generic;

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
            { "ryebread", new string[] { "icelandic", "finnish" }},
            { "flatbread", new string[] { "middle eastern", "italian" }},
            { "sourdough", new string[] { "german", "italian", "american" }},
            { "custard", new string[] { "french", "portuguese", "japanese" }},
            { "macaroon", new string[] { "french", "filipino" }},
            { "strudel", new string[] { "austrian", "turkish", "hungarian" }},
        };

        public static bool HasOption(string product, string option)
        {
            return options.ContainsKey(product) && Array.Exists(options[product], e => e == option);
        }

        public static bool HasVariety(string option, string variety)
        {
            if (option == "bread" || option == "pastry")
                return Array.Exists(specials[option], e => e == variety);
            return varieties.ContainsKey(option) && Array.Exists(varieties[option], e => e == variety);
        }

        public static string GetOptions(string product)
        {
            if (!options.ContainsKey(product))
                return "";
            return stringify(options[product]);
        }

        public static string GetVarieties(string option)
        {
            if (!varieties.ContainsKey(option))
                return "";
            return stringify(varieties[option]);
        }

        public static string GetVarieties(string product, string option)
        {
            if (option == "special")
                return GetSpecial(product);
            return GetVarieties(option);
        }

        public static string GetSpecial(string product)
        {
            if (!specials.ContainsKey(product))
                return "";
            int s = (new Random()).Next(0, specials[product].Length);
            int o = (new Random()).Next(0, specials[product].Length);
            while (o == s)
                o = (new Random()).Next(0, specials[product].Length);
            string[] varieties = new string[] {
                specials[product][s],
                specials[product][o]
            };
            return stringify(varieties);
        }

        private static string stringify(string[] items)
        {
            string list = "";
            for (int i = 0; i < items.Length; i++)
            {
                if (i == items.Length - 1)
                    list += "and ";
                list += items[i];
                if (i != items.Length - 1)
                {
                    list += items.Length == 2 ? " " : ", ";
                }
            }
            return list;
        }
    }
}