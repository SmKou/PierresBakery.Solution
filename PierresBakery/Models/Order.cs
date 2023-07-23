using System.Linq;

namespace PierresBakery.Models;

public static class Order
{
    private static Dictionary<string, Item> _items = new Dictionary<string, Item>();

    public static bool IsEmpty()
    {
        return _items.Count == 0;
    }

    public static bool Has(string itemName)
    {
        return _items.ContainsKey(itemName);
    }

    public static void AddItem(Item item)
    {
        string itemName = $"{item.Option}-{item.Variety}";
        if (Has(itemName))
            _items[itemName].Quantity = item.Quantity;
        else
            _items.Add(itemName, item);
    }

    public static bool ChangeQty(string itemName, int qty)
    {
        if (Has(itemName))
        {
            _items[itemName].Quantity = qty;
            return true;
        }
        return false;
    }

    public static bool DeleteItem(string itemName)
    {
        if (Has(itemName))
        {
            _items.Remove(itemName);
            return true;
        }
        return false;
    }

    public static Item[] Items()
    {
        Item[] items = new Item[_items.Count];
        _items.Values.CopyTo(items, 0);
        return items;
    }

    public static int Total()
    {
        List<int> subtotals = new List<int>();
        foreach (Item item in _items.Values)
            subtotals.Add(item.Total());
        return subtotals.Sum();
    }

    /* use for testing */
    public static void ClearAll()
    {
        _items.Clear();
    }
}
