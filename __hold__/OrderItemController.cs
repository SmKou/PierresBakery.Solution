namespace PierresBakery.Controllers;

public static class OrderItemController
{
    public static string Option { get; set; }
    public static string Variety { get; set; }
    public static int Quantity { get; set; }
    public static bool Error { get; set; }

    private static Dictionary<string, string> _prompts = new Dictionary<string, string>
    {
        
    };
}