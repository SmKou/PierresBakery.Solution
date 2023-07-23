namespace PierresBakery.Models;

public abstract class Item
{
    public string Product { get; }
    public string Option { get; set; }
    public int OptionId { get; set; }
    public string Variety { get; set; }
    public int Quantity { get; set; }

    public Item(string product)
    {
        Product = product;
    }

    public abstract int Total();
}