namespace PierresBakery.Models;

public static class Menu
{
    private static Dictionary<string, Option[]> _products = new Dictionary<string, Option[]> {
        {"bread", new Option[] {
            new Option(
                "bread",
                new string[] {"french", "italian", "portuguese", "american"},
                5, 2
            ),
            new Option(
                "ryebread",
                new string[] {"icelandic", "finnish"},
                8, 2
            ),
            new Option(
                "flatbread",
                new string[] {"middle eastern", "italian"},
                6, 4
            ),
            new Option(
                "sourdough",
                new string[] {"german", "italian", "american"},
                7, 2
            )
        }},
        {"pastry", new Option[] {
            new Option(
                "pastry",
                new string[] {"filipino", "austrian", "portuguese", "french"},
                2, 3
            ),
            new Option(
                "custard",
                new string[] {"french", "portuguese", "japanese"},
                3, 6
            ),
            new Option(
                "macaroon",
                new string[] {"french", "filipino"},
                1, 8
            ),
            new Option(
                "strudel",
                new string[] {"austrian", "turkish", "hungarian"},
                5, 3
            )
        }}
    };

    public static bool HasProduct(string product)
    {
        return _products.ContainsKey(product);
    }

    public static bool HasOption(string product, string option)
    {
        return Array.Exists(_products[product], opt => opt.Name == option);
    }

    public static bool HasVariety(string product, int optionId, string variety)
    {
        return Array.Exists(Get(product, optionId).Varieties, v => v == variety);
    }

    public static int Find(string product, string option)
    {
        if (!HasProduct(product))
            return -1;
        for (int i = 0; i < _products[product].Length; i++)
            if (_products[product][i].Name == option)
                return i;
        return -1;
    }

    public static string[] Options(string product)
    {
        string[] options = new string[_products[product].Length];
        for (int i = 0; i < options.Length; i++)
            options[i] = _products[product][i].Name;
        return options;
    }

    private static Option Get(string product, int optionId)
    {
        return _products[product][optionId];
    }

    public static string[] Varieties(string product, int optionId)
    {
        return Get(product, optionId).Varieties;
    }

    public static int Cost(string product, int optionId)
    {
        return Get(product, optionId).Cost;
    }

    public static int Deal(string product, int optionId)
    {
        return Get(product, optionId).Deal;
    }
}
