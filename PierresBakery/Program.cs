global using System;
global using System.Collections.Generic;
using PierresBakery.Models;

namespace PierresBakery;

public class Program
{
    public static string Operation { get; set; }
    public static string[] Commands = new string[] {
        "order",
        "view",
        "remind",
        "cancel",
        "stop",
        "submit",
    };

    private static bool IsCommand(string response)
    {
        return Array.Exists(Commands, c => c == response);
    }

    public static void Main()
    {
        Console.WriteLine("Welcome to Pierre's Bakery!\nI'll be your assistant for today. Today, the house bread is $5, buy 2 and get 1 free, and the house pastry is $5, buy 3 and get 1 free.\n\nBefore we begin, here are the commands I can follow:");
        Operation = "remind";

        while (Operation != "stop")
        {
            if (Operation == "remind")
            {
                Console.WriteLine("Add another item to your order: order\nLeave without completing your order: stop\nCancel a process like entering an item or viewing your order: cancel\nView your order: view\nSubmit your order: submit\nPull up available commands: remind\n");
                Operation = "order";
            }
            else if (Operation == "order")
            {
                Console.WriteLine("What would you like to do: " + (!Order.IsEmpty() ? "view your order, or " : "") + "order bread or pastry?");
                string response = Console.ReadLine();
                if (IsCommand(response))
                    Operation = response;
                else if (response == "bread" || response == "pastry")
                {
                    Item item = response == "bread" ? new Bread() : new Pastry();
                    RunOrder(item);
                }
            }
            else if (Operation == "view")
            {
                if (!Order.IsEmpty())
                    RunView();
                else
                    Empty();
            }
            else if (Operation == "cancel")
                Operation = "prompt";
            else if (Operation == "submit")
            {
                if (!Order.IsEmpty())
                {
                    Console.WriteLine("Your order has been submitted!");
                    Operation = "stop";
                }
                else
                    Empty();
            }
        }
        Console.WriteLine("Thank you for stopping by Pierre's Bakery. Bye bye!");
    }

    private static void Empty()
    {
        Console.WriteLine("You have not added any items to your order yet.");
        Operation = "order";
    }

    private static bool RunView()
    {
        Item[] items = Order.Items();
        Item item = null;
        while (Operation == "view")
        {
            string[] lines = Format.OrderList(items);
            foreach (string line in lines)
                Console.WriteLine(line);

            if (Order.IsEmpty())
            {
                Operation = "order";
                return false;
            }
            Console.WriteLine("What would you like to do?\nDelete an item: del [number]\nChange quantity: chg [number] [qty]\nAdd item to order: order");
            string response = Console.ReadLine();

            if (IsCommand(response))
                Operation = response;
            else if (response.Contains("del"))
            {
                string[] cmd = response.Split(" ");
                if (cmd.Length == 2)
                {
                    try
                    {
                        int n = int.Parse(cmd[1]) - 1;
                        if (n >= 0 && n < items.Length)
                        {
                            item = items[n];
                            string plural = item.Quantity > 1 ? "s" : "";
                            Console.WriteLine($"Deleting {item.Quantity} {item.Variety} {item.Option}{plural} from order...");
                            string itemName = $"{item.Option}-{item.Variety}";
                            Order.DeleteItem(itemName);
                            items = Order.Items();
                            item = null;
                        }
                        else
                            Console.WriteLine("That number is not on your order.");
                    }
                    catch
                    {
                        Console.WriteLine("Not a valid command.");
                    }
                }
                else
                    Console.WriteLine("Not a valid command.");
            }
            else if (response.Contains("chg"))
            {
                Console.WriteLine("Requesting change");
                string[] cmd = response.Split(" ");
                if (cmd.Length == 3)
                {
                    try
                    {
                        int n = int.Parse(cmd[1]) - 1;
                        int qty = int.Parse(cmd[2]);
                        if (n >= 0 && n < items.Length && qty > 0)
                        {
                            item = items[n];
                            string plural = item.Quantity > 1 ? "s" : "";
                            Console.WriteLine($"Changing {item.Quantity} {item.Variety} {item.Option}{plural} to {qty}...");
                            string itemName = $"{item.Option}-{item.Variety}";
                            Order.ChangeQty(itemName, qty);
                            items = Order.Items();
                            item = null;
                        }
                        else
                            Console.WriteLine("Your numbers are invalid.");
                    }
                    catch
                    {
                        Console.WriteLine("Not a valid command.");
                    }
                }
                else
                    Console.WriteLine("Not a valid command.");
            }
        }
        return true;
    }

    private static bool RunOrder(Item item)
    {
        string subop = "option";
        while (Operation == "order")
        {
            bool received = false;
            string list = "";
            while (!received)
            {
                switch (subop)
                {
                    case "option":
                        list = Format.List(Menu.Options(item.Product));
                        Console.WriteLine($"We offer {list}. What {item.Product} would you like?");
                        break;
                    case "variety":
                        list = Format.List(Menu.Varieties(item.Product, item.OptionId));
                        Console.WriteLine($"What variety would you like? We offer {list}.");
                        break;
                    case "quantity":
                        int cost = Menu.Cost(item.Product, item.OptionId);
                        int deal = Menu.Deal(item.Product, item.OptionId);
                        Console.WriteLine($"A {item.Option} costs ${cost}. Buy {deal} and get 1 free. How many would you like?");
                        break;
                    case "confirm":
                        Operation = "order";
                        Order.AddItem(item);
                        string plural = item.Quantity > 1 ? "s" : "";
                        Console.WriteLine($"You have added {item.Quantity} {item.Variety} {item.Option}{plural} to your order!");
                        return true;
                    default:
                        return false;
                }

                string response = Console.ReadLine();
                if (IsCommand(response))
                {
                    Operation = response;
                    received = true;
                }
                else
                    switch (subop)
                    {
                        case "option":
                            if (Menu.HasOption(item.Product, response))
                            {
                                item.Option = response;
                                item.OptionId = Menu.Find(item.Product, item.Option);
                                subop = "variety";
                                received = true;
                            }
                            break;
                        case "variety":
                            if (Menu.HasVariety(item.Product, item.OptionId, response))
                            {
                                item.Variety = response;
                                subop = "quantity";
                                received = true;
                            }
                            break;
                        case "quantity":
                            try
                            {
                                int n = int.Parse(response);
                                if (n > 0)
                                {
                                    item.Quantity = n;
                                    subop = "confirm";
                                    received = true;
                                }
                            }
                            catch
                            {
                                subop = "quantity";
                                received = false;
                            }
                            break;
                    }
            }
        }
        return true;
    }
}
