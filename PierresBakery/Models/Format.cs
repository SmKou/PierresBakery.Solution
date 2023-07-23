namespace PierresBakery.Models;

public static class Format
{
    private static int _lineLength = 54;

    public static string[] OrderList(Item[] items)
    {
        List<string> order = new List<string>();

        string divider = "";
        for (int i = 0; i < _lineLength; i++)
            divider += "-";
        order.Add(divider);
        int blankSpaces = 0;

        if (items.Length > 0)
        {
            for (int i = 0; i < items.Length; i++)
            {
                string line = Format.Item(items[i]);
                string listing = (i + 1).ToString() + ".";
                blankSpaces = 5 - listing.Length;
                for (int j = 0; j < blankSpaces; j++)
                    listing += " ";
                listing += line;
                order.Add(listing);
            }
        }
        else
            order.Add("You have no items in your order.");
        order.Add(divider);

        if (items.Length > 0)
        {
            string line = "$" + Order.Total().ToString();
            string listing = "Total";
            blankSpaces = _lineLength - (4 + listing.Length);
            for (int i = 0; i < blankSpaces; i++)
                listing += " ";
            listing += line;
            order.Add(listing);
            order.Add(divider);
        }

        return order.ToArray();
    }

    private static string Item(Item item)
    {
        string line = item.Option[0].ToString().ToUpper() + item.Option.Substring(1);
        line += $" - {item.Variety}";

        int blankSpace = 40 - line.Length;
        for (int i = 0; i < blankSpace; i++)
            line += " ";

        if (item.Quantity > 0)
        {
            string qty = item.Quantity.ToString();
            line += qty;
            blankSpace = 5 - qty.Length;
            for (int i = 0; i < blankSpace; i++)
                line += " ";

            string ttl = item.Total().ToString();
            line += "$" + ttl;
        }
        else
            line += "0";

        return line;
    }

    public static string List(string[] listings)
    {
        if (listings.Length == 0)
            return "not available";
        else if (listings.Length == 1)
            return listings[0];
        else if (listings.Length == 2)
            return listings[0] + " and " + listings[1];

        string line = "";
        for (int i = 0; i < listings.Length; i++)
        {
            if (i == listings.Length - 1)
                line += "and ";
            line += listings[i];
            if (i != listings.Length - 1)
                line += ", ";
        }
        return line;
    }
}