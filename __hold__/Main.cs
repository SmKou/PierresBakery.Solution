namespace PierresBakery.Views;

public static class Main
{
    public static void Intro()
    {
        Console.WriteLine("Welcome to Pierre's Bakery!\nI'll be your assistant for today. Today, the house bread is $5, buy 2 and get 1 free, and the house pastry is $5, buy 3 and get 1 free.\n\nBefore we begin, if you need to leave at any time without completing your order, type in cancel or stop.\nIf you wish to return to this menu, type in menu, and if you would like to view your order, type in view.\nYou will only have the option of submitting your order when reviewing it.\nNow then.\n\n");
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
        Console.WriteLine("Thank you for stopping by Pierre's Bakery. Bye bye!");
    }
}