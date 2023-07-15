using System;
using PierresBakery.Models;

namespace PierresBakery.Views
{
    public class OrderMenuItem
    {
        private static bool isCommand(string input)
        {
            return input == "cancel" || input == "stop" || input == "menu";
        }

        private static int ConvertCommand(string input)
        {
            switch (input)
            {
                case "cancel":
                case "stop":
                    return -1;
                case "menu":
                    return -2;
                default:
                    return -3;
            }
        }

        private static string ConvertCommand(int input)
        {
            switch (input)
            {
                case -1:
                    return "stop";
                case -2:
                    return "menu";
                default:
                    return "error";
            }
        }

        public static string run(bool state, string product, Order order)
        {
            Console.WriteLine("We offer " + Menu.GetOptions(product) + "\nWhat would you like?");

            string op = "opt";
            string option = "";
            string variety = "";
            int qty = 0;
            while (state)
            {
                switch (op)
                {
                    case "opt":
                    case "option":
                        option = GetOption(state, product);
                        if (isCommand(option))
                            return option;
                        if (option.Length == 0)
                            break;
                        op = "var";
                        break;
                    case "var":
                        variety = GetVariety(state, product, option);
                        if (isCommand(variety))
                            return variety;
                        if (variety.Length == 0)
                            break;
                        op = "qty";
                        break;
                    case "qty":
                        qty = GetQuantity(state, option);
                        if (qty < 0)
                            return ConvertCommand(qty);
                        op = "edit";
                        break;
                    case "edit":
                        string plural = qty > 1 ? "s" : "";
                        Console.WriteLine($"You are ordering {qty} {option}{plural} {variety}");
                        Console.WriteLine("Please confirm that you would like to add this to your order: yes or no.");
                        op = Console.ReadLine();
                        break;
                    case "y":
                    case "yes":
                        state = false;
                        break;
                    case "n":
                    case "no":
                        Console.WriteLine($"What would you like to change? Type in option to change {option}, variety to change {variety}, or quantity to change {qty}.");
                        op = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Returning to menu...");
                        return "menu";
                }
            }

            string item = $"{option}-{variety}";
            if (order.HasItem(item))
                order.ChangeQty(item, qty);
            else
            {
                MenuItem details = product == "bread" ? new Bread(option) : new Pastry(option);
                details.ItemVariety = variety;
                details.Quantity = qty;
                order.AddItem(item, details);
            }

            Console.WriteLine("Would you like to see your order or order more bread and pastries?");
            return Console.ReadLine();
        }

        private static string GetOption(bool state, string product)
        {
            string option = "";
            while (state)
            {
                option = Console.ReadLine();
                if (isCommand(option))
                    return option;

                if (Menu.HasOption(product, option))
                {
                    string varieties = option == "special" ? Menu.GetVarieties(product, option) : Menu.GetVarieties(option);
                    Console.WriteLine("What variety would you like? We offer " + varieties);
                    return option;
                }
                else
                    Console.WriteLine($"We do not offer {option}. Only " + Menu.GetOptions(product));
            }
            return option;
        }

        private static string GetVariety(bool state, string product, string option)
        {
            string variety = "";
            while (state)
            {
                variety = Console.ReadLine();
                if (isCommand(variety))
                    return variety;

                if ((option == "special" && Menu.HasVariety(product, variety)) || Menu.HasVariety(option, variety))
                {
                    state = false;
                    break;
                }
                else
                    Console.WriteLine($"We do not offer {variety}. Only " + Menu.GetVarieties(option));
            }
            int cost = product == "bread" ? Bread.ItemCost(option) : Pastry.ItemCost(option);
            int deal = product == "bread" ? Bread.ItemDeal(option) : Pastry.ItemDeal(option);
            string item = option == "special" ? $"{option} {product}" : option;
            Console.WriteLine($"A {item} costs ${cost}. Buy {deal} and get 1 free. How many would you like?");
            return variety;
        }

        private static int GetQuantity(bool state, string option)
        {
            string response = "";
            int qty = 0;
            while (state)
            {
                response = Console.ReadLine();
                if (isCommand(response))
                    return ConvertCommand(response);

                try
                {
                    qty = int.Parse(response);
                    return qty;
                }
                catch
                {
                    Console.WriteLine($"Apologies. But {response} is not a number. How many {option}s would you like?");
                }
            }
            return qty;
        }
    }
}