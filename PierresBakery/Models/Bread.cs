namespace PierresBakery.Models;

public class Bread : Item
{
    public Bread() : base("bread") {}

    public override int Total()
    {
        int deal = Menu.Deal(Product, OptionId);
        int cost = Menu.Cost(Product, OptionId);

        int free = Quantity / (deal + 1);
        return (Quantity - free) * cost;
    }
}