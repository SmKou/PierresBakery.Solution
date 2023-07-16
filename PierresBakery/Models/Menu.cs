using System;
using System.Collections.Generic;

namespace PierresBakery.Models
{
    public static class Menu
    {
        private class Option
        {
            public string[] Varieties { get; }
            public int Cost { get; }
            public int Deal { get; }

            public Option(string[] varieties, int cost, int deal)
            {
                Varieties = varieties;
                Cost = cost;
                Deal = deal;
            }
        }

        private static Dictionary<string, string[]> _products = new Dictionary<string, string[]> 
        {
            {"bread", new string[] {"ryebread", "flatbread", "sourdough", "bread"}},
            {"pastry", new string[] {"custard", "macaroon", "strudel", "pastry"}}
        };

        private static Dictionary<string, Option> _options = new Dictionary<string, Option> 
        {
            {"bread", new Option(
                new string[] {"french", "italian", "portuguese", "american"},
                5, 2
            )},
            {"ryebread", new Option(
                new string[] {"icelandic", "finnish"},
                8, 2
            )},
            {"flatbread", new Option(
                new string[] {"middle eastern", "italian"},
                6, 4
            )},
            {"sourdough", new Option(
                new string[] {"german", "italian", "american"},
                7, 2
            )},
            {"pastry", new Option(
                new string[] {"filipino", "austrian", "portuguese", "french"},
                2, 3
            )},
            {"custard",  new Option(
                new string[] {"french", "portuguese", "japanese"},
                3, 6
            )},
            {"macaroon", new Option(
                new string[] {"french", "filipino"},
                1, 8
            )},
            {"strudel", new Option(
                new string[] {"austrian", "turkish", "hungarian"},
                5, 3
            )}
        };

        public static bool HasOption(string product, string option)
        {
            return _products.ContainsKey(product) && HasElement(_products[product], option);
        }

        public static bool HasVariety(string option, string variety)
        {
            return _options.ContainsKey(option) && HasElement(_options[option].Varieties, variety);
        }

        private static bool HasElement(string[] arr, string match)
        {
            return Array.Exists(arr, e => e == match);
        }

        public static string Options(string product)
        {
            return !_products.ContainsKey(product) ? "" : stringify(_products[product]);
        }

        public static string Varieties(string option)
        {
            return !_options.ContainsKey(option) ? "" : stringify(_options[option].Varieties);
        }

        public static int Cost(string option)
        {
            return !_options.ContainsKey(option) ? -1 : _options[option].Cost;
        }

        public static int Deal(string option)
        {
            return !_options.ContainsKey(option) ? -1 : _options[option].Deal;
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