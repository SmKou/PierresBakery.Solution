namespace PierresBakery.Views;

public static class Main
{
    public static void Intro()
    {
        Console.WriteLine();
        Menu();
    }

    public static void Menu()
    {
        Console.WriteLine("What would you like to order: bread or pastries?");
    }

    public static void Reset()
    {
        Console.WriteLine("You have no submitted order. I am sorry to see you go.");
    }

    public static void Submit()
    {
        Console.WriteLine("Your order has been submitted.");
    }

    public static void Unknown(string op)
    {
        Console.WriteLine($"I do not understand {op}. Do you still wish to continue: yes or no?");
    }

    public static void End()
    {
        Console.WriteLine();
    }
}