using System;
using PierresBakery.Models;
using PierresBakery.Views;

namespace PierresBakery
{
    public class PierresBakery
    {
        public static void Main()
        {
            bool state = true;
            string op = "menu";
            Order order = new Order();
            Console.WriteLine("Welcome to Pierre's Bakery\nI'll be your robot today.\nBefore we begin, when you're ready to leave, type in cancel or stop. If you wish to return to this menu, type in menu, and if you would like to view your order, type in view or order.\nNow then.");
            
            while (state)
            {
                switch (op)
                {
                    case "bread":
                        op = OrderMenuItem.run(true, "bread", order);
                        break;
                    case "pastry":
                    case "pastries":
                        op = OrderMenuItem.run(true, "pastry", order);
                        break;
                    case "menu":
                        Console.WriteLine("What would you like to order: bread or pastries?");
                        op = Console.ReadLine();
                        break;
                    case "view":
                    case "order":
                        op = ReviewOrder.run(true, order);
                        break;
                    case "y":
                    case "yes":
                        op = "menu";
                        break;
                    case "cancel":
                    case "stop":
                    case "n":
                    case "no":
                        Console.WriteLine("Thank you for stopping by Pierre's Bakery. Bye bye!");
                        state = false;
                        break;
                    case "submit":
                        Console.WriteLine("Your order has been submitted.");
                        op = "no";
                        break;
                    default:
                        Console.WriteLine($"I did not understand {op}. Do you still wish to continue?");
                        break;
                }
            }
        }
    }
}