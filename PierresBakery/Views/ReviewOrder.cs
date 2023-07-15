using System;
using PierresBakery.Models;

namespace PierresBakery.Views
{
    public class ReviewOrder
    {
        public static string run(bool state, Order order)
        {
            string op = "instruct";
            string[] cmd = new string[] { "" };
            string[] items = new string[] { "" };
            int n = -1;
            bool result = false;
            while (state)
            {
                switch (op)
                {
                    case "stop":
                    case "cancel":
                        return "stop";
                    case "menu":
                        return "menu";
                    case "ready":
                    case "pay":
                    case "submit":
                        return "submit";
                    case "instruct":
                        Console.WriteLine("For your convenience, the items of your order have been numbered. You can delete and edit the items on your order by typing in del or delete, eg. del 1 to delete the first item. You can change quantities with change or chg line number and new quantity, eg. chg 1 5. If you need to view these instructions again, type in instruct. If you just want a brief reminder, type in remind.");
                        Console.WriteLine("Remember if you want to return to the menu, type in menu. If you're ready to submit your order, type in ready, pay or submit.");
                        op = "view";
                        break;
                    case "remind":
                        Console.WriteLine("del or delete n\nchg or change n qty");
                        op = "view";
                        break;
                    case "view":
                        Console.WriteLine("Here is your order:");
                        Array.ForEach(order.GetOrder(), Console.WriteLine);
                        Console.WriteLine("What would you like to do?");
                        cmd = Console.ReadLine().Split(" ");
                        op = cmd[0];
                        break;
                    case "next":
                        cmd = Console.ReadLine().Split(" ");
                        op = cmd[0];
                        break;
                    case "index-error":
                        Console.WriteLine("Not a valid number from your order list. Please try again.");
                        op = "next";
                        break;
                    case "del":
                    case "delete":
                        items = order.GetItems();
                        n = GetIndex(cmd[1], items);
                        if (n < 0)
                        {
                            op = "index-error";
                            break;
                        }
                        result = order.DeleteItem(items[n]);
                        if (!result)
                        {
                            Console.WriteLine("I could not delete the item. Please try again.");
                            op = "next";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Item deleted.");
                            op = "view";
                            break;
                        }
                    case "chg":
                    case "change":
                        items = order.GetItems();
                        n = GetIndex(cmd[1], items);
                        if (n < 0)
                        {
                            op = "index-error";
                            break;
                        }
                        result = order.ChangeQty(items[n], n);
                        if (!result)
                        {
                            Console.WriteLine("I could not change the quantity of the item. Please try again.");
                            op = "next";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Quantity changed.");
                            op = "view";
                            break;
                        }
                    default:
                        Console.WriteLine("Returning to menu...");
                        return "menu";
                }
            }
            return "menu";
        }

        private static int GetIndex(string cmd, string[] items)
        {
            int n = 0;
            try
            {
                n = int.Parse(cmd);
            }
            catch
            {
                return -1;
            }
            
            if (n < 0 || n > items.Length - 1)
                return -1;
            return n;
        }
    }
}