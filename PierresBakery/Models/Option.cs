namespace PierresBakery.Models;

public class Option
{
    public string Name { get; }
    public string[] Varieties { get; }
    public int Cost { get; }
    public int Deal { get; }

    public Option(string name, string[] varieties, int cost, int deal)
    {
        Name = name;
        Varieties = varieties;
        Cost = cost;
        Deal = deal;
    }
}