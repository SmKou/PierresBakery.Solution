using System;
using PierresBakery.Models;

namespace PierresBakery
{
    public class PierresBakery
    {
        public static void Main()
        {
            bool state = true;
            string view = "menu";
            Order order = new Order();
            Console.WriteLine("Welcome to Pierre's Bakery\nI'll be your robot today.\nBefore we begin, when you're ready to leave, tell me cancel or stop.\nNow then. ");
            
            while (state)
            {
                switch (answer)
                {
                    case "bread":
                        answer = orderMenuItem(true, "bread");
                        break;
                    case "pastry":
                    case "pastries":
                        answer = orderMenuItem(true, "pastry");
                        break;
                    case "menu":
                        Console.WriteLine("What would you like to order: bread or pastries?")
                        answer = Console.ReadLine();
                        break;
                    case "y":
                    case "yes":
                        answer = "menu";
                        break;
                    case "cancel":
                    case "stop":
                    case "n":
                    case "no":
                        console.WriteLine("Thank you for stopping by Pierre's Bakery. Bye bye!");
                        state = false;
                        breal;
                    default:
                        console.WriteLine($"I did not understand {answer}. Do you still wish to continue: yes or no?");
                }
            }
        }

        private static string orderMenuItem(bool state, string product, Order order)
        {
            Console.WriteLine("We offer " + order.getOptions(product) + "\nWhat would you like?");
            string item = Console.ReadLine();
            int qty = 0;
            while (state)
            {
                try {
                    qty = int.Parse(item);

                    state = false;
                    continue;
                }
                catch { qty = 0; }

                switch (item)
                {
                    case "cancel":
                    case "stop":
                        return "stop";
                    case "selection":
                        Console.WriteLine("What variety would you like?")
                    default:
                }
            }

        }
    }
}