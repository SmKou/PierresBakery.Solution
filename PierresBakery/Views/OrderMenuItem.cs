using System;
using PierresBakery.Models;

namespace PierresBakery.Views
{
    public class OrderMenuItem
    {
        private static string op = "option";
        private static string[] cmd = new string[0];
        private static string option = "";
        private static string variety = "";
        private static int quantity = 0;

        public static string Run(bool state, Order order, string product)
        {
            while (state)
            {
                switch (op)
                {
                    case "stop":
                    case "cancel":
                        return "stop";
                    case "menu":
                        return "menu";
                    case "view":
                        return "view";
                    case "option":
                        op = RunOption(product);
                        break;
                    case "variety":
                        op = RunVariety(product);
                        break;
                    case "quantity":
                        op = RunQuantity();
                        break;
                    case "confirm":
                        op = RunConfirm();
                        break;
                    case "y":
                    case "yes":
                        state = false;
                        break;
                    case "n":
                    case "no":
                        op = RunEdit();
                        break;
                    case "error":
                        op = RunError(product);
                        break;
                    default:
                        cmd = new string[] { "unknown", op };
                        op = "error";
                        break;
                }
            }

            MenuItem item = NewItem(product);
            if (Object.ReferenceEquals(item, null))
            {
                Console.WriteLine("Something is wrong. I could not add the item to your order. Returning to menu...");
                return "menu";
            }
            order.AddItem(item);
            Console.WriteLine("Would you like to view your order, or order another bread or pastry: view, bread, or pastry?");
            return Console.ReadLine();
        }

        private static bool isCommand(string response)
        {
            return response == "stop" || response == "cancel" || response == "menu" || response == "view";
        }

        private static MenuItem NewItem(string product)
        {
            switch (product)
            {
                case "bread":
                    return new Bread(option, variety, quantity);
                case "pastry":
                    return new Pastry(option, variety, quantity);
                default:
                    return null;
            }
        }

        private static string RunOption(string product)
        {
            Console.WriteLine("We offer " + Menu.Options(product) + "\nWhat would you like?");
            string response = Console.ReadLine();
            if (isCommand(response))
                return response;

            if (Menu.HasOption(product, response))
            {
                option = response;
                return "variety";
            }
            else
            {
                cmd = new string[] { "option", response };
                return "error";
            }
        }

        private static string RunVariety(string product)
        {
            Console.WriteLine("What variety would you like? We offer " + Menu.Varieties(option));
            string response = Console.ReadLine();
            if (isCommand(response))
                return response;

            if (Menu.HasVariety(option, response))
            {
                variety = response;
                return "quantity";
            }
            else
            {
                cmd = new string[] { "variety", response };
                return "error";
            }
        }

        private static string RunQuantity()
        {
            Console.WriteLine($"A {option} costs ${Menu.Cost(option)}. Buy {Menu.Deal(option)} and get 1 free. How many would you like?");
            string response = Console.ReadLine();
            if (isCommand(response))
                return response;
            
            try
            {
                quantity = int.Parse(response);
                if (quantity < 1)
                {
                    cmd = new string[] { "quantity", response };
                    return "error";
                }
                return "confirm";
            }
            catch
            {
                cmd = new string[] { "quantity", response };
                return "error";
            }
        }

        private static string RunConfirm()
        {
            string plural = quantity > 1 ? "s" : "";
            Console.WriteLine($"You are ordering {quantity} {option}{plural} {variety}. Would you like to add this to your order: yes or no?");
            return Console.ReadLine();
        }

        private static string RunEdit()
        {
            Console.WriteLine("What would you like to change: option, variety, or quantity?");
            return Console.ReadLine();
        }

        private static string RunError(string product)
        {
            if (cmd[0] == "option" || cmd[0] == "variety")
                Console.WriteLine($"We do not offer {cmd[1]}.");
            else if (cmd[0] == "quantity")
                Console.WriteLine($"Sorry, but {cmd[1]} is not a valid number.");
            else if (cmd[0] == "unknown")
            {
                Console.WriteLine($"I do not understand the command: {cmd[1]}.");
                if (option == "")
                {
                    Console.WriteLine($"I see that you haven't selected an option of {product}.");
                    return "option";
                }
                else if (variety == "")
                {
                    Console.WriteLine($"I see that you haven't selected a variety of {option}.");
                    return "variety";
                }
                else if (quantity == 0)
                {
                    Console.WriteLine($"I see that you haven't entered a quantity for {variety} {option}.");
                    return "quantity";
                }
                return "confirm";
            }
            return cmd[0];
        }
    }
}