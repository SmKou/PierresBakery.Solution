namespace PierresBakery.Models;

public class Pastry : Item
{
    public Pastry(string option, string variety, int qty) : base("pastry", option, variety, qty) { }

    public override int Total()
    {
        int deal = Menu.Deal(Product, OptionId);
        int cost = Menu.Cost(Product, OptionId);

        int free = Quantity / (deal + 1);
        return (Quantity - free) * cost;
    }
}
