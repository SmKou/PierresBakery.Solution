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
            Console.WriteLine("Welcome to Pierre's Bakery!\nI'll be your assistant for today. Today, the house bread is $5, buy 2 and get 1 free, and the house pastry is $5, buy 3 and get 1 free.\nBefore we begin, if you need to leave at any time without completing your order, type in cancel or stop.\nIf you wish to return to this menu, type in menu, and if you would like to view your order, type in view.\nYou will only have the option of submitting your order when reviewing it.\nNow then.\n\n");
            
            while (state)
            {
                switch (op)
                {
                    case "menu":
                        Console.WriteLine("What would you like to order: bread or pastries?");
                        op = Console.ReadLine();
                        break;
                    case "bread":
                        op = OrderMenuItem.Run(true, order, "bread");
                        break;
                    case "pastry":
                    case "pastries":
                        op = OrderMenuItem.Run(true, order, "pastry");
                        break;
                    case "view":
                    case "review":
                        op = ReviewOrder.Run(true, order);
                        break;
                    case "y":
                    case "yes":
                        op = "menu";
                        break;
                    case "cancel":
                    case "stop":
                    case "n":
                    case "no":
                        Console.WriteLine("You have no submitted order. I am sorry to see you go.");
                        state = false;
                        break;
                    case "submit":
                        Console.WriteLine("Your order has been submitted.");
                        state = false;
                        break;
                    default:
                        Console.WriteLine($"I did not understand {op}. Do you still wish to continue: yes or no?");
                        op = Console.ReadLine();
                        break;
                }
            }
            Console.WriteLine("Thank you for stopping by Pierre's Bakery. Bye bye!");
        }
    }
}