namespace PierresBakery.Models;

public abstract class Item
{
    public string Product { get; }
    public string Option { get; }
    public int OptionId { get; }
    public string Variety { get; set; }
    public int Quantity { get; set; }

    public Item(string product, string option, string variety, int qty)
    {
        Product = product;
        Option = option;
        Variety = variety;
        Quantity = qty;
        OptionId = Menu.Find(product, option);
    }

    public abstract int Total();
}