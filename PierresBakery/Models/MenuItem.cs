namespace PierresBakery.Models
{
    public class MenuItem
    {
        public string ItemName { get; }
        public int Cost { get; }
        public int DealAmount { get; }

        public MenuItem(string itemName, int cost, int dealAmount)
        {
            ItemName = itemName;
            Cost = cost;
            DealAmount = dealAmount;
        }

        public int GetSubtotal(int n)
        {
            int free_items = n / (DealAmount + 1);
            return (n - free_items) * Cost;
        }
    }

    public class Bread : MenuItem
    {
        public Bread() : base("bread", 5, 2) {}
    }

    public class Pastry: MenuItem
    {
        public Pastry() : base("pastry", 2, 3) {}
    }
}