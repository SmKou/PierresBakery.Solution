namespace PierresBakery.Controllers;

public static class MainController
{
    public static bool State { get; set; } = true;
    public static string Operation { get; set; }
    public static Order Receipt { get; set; }

    private static string[] _commands = new string[] {
        "menu",
        "cancel",
        "stop",
        "view",
        "error"
    };

    public static bool IsCommand(string response)
    {
        return Array.Exists(_commands, e => e == response);
    }

    
}