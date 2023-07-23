namespace PierresBakery.Models;

public class Bread : Item
{
    public Bread(string option, string variety, int qty) : base("bread", option, variety, qty) { }

    public override int Total()
    {
        int deal = Menu.Deal(Product, OptionId);
        int cost = Menu.Cost(Product, OptionId);

        int free = Quantity / (deal + 1);
        return (Quantity - free) * cost;
    }
}