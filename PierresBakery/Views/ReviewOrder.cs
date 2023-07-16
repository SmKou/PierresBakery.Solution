using System;
using PierresBakery.Models;

namespace PierresBakery.Views
{
    public static class ReviewOrder
    {
        private static string op = "instruct";
        private static string[] cmd = new string[0];
        private static string[] items = new string[0];

        public static string Run(bool state, Order order)
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
                    case "submit":
                        return "submit";
                    case "instruct":
                        op = RunInstruct();
                        break;
                    case "remind":
                        op = RunRemind();
                        break;
                    case "view":
                        op = RunView(order);
                        break;
                    case "error":
                        op = RunError(cmd[1]);
                        break;
                    case "del":
                    case "delete":
                        op = RunDelete(order);
                        break;
                    case "chg":
                    case "change":
                        op = RunChange(order);
                        break;
                    default:
                        state = false;
                        break;
                }
            }
            Console.WriteLine("Returning to menu...");
            return "menu";
        }

        private static string RunInstruct()
        {
            Console.WriteLine("For your convenience, the items of your order have been numbered. You can delete and edit the items on your order by typing in del or delete, eg. del 1 to delete the first item. You can change quantities with change or chg line number and new quantity, eg. chg 1 5. If you need to view these instructions again, type in instruct. If you just want a brief reminder, type in remind.");
            Console.WriteLine("Remember if you want to return to the menu, type in menu. If you're ready to submit your order, type in submit.");
            return "view";
        }

        private static string RunRemind()
        {
            Console.WriteLine("del or delete n\nchg or change n qty");
            return "view";
        }

        private static string RunView(Order order)
        {
            Console.WriteLine("Here is your order:");
            Array.ForEach(order.Receipt(), Console.WriteLine);
            Console.WriteLine("What would you like to do: stop, menu, del, or chg?");
            cmd = Console.ReadLine().Split(" ");
            return cmd[0];
        }

        private static string RunDelete(Order order)
        {
            items = order.Items();
            int n = Index(cmd[0]);
            if (n < 0)
                return cmd[0];
            
            bool result = order.DeleteItem(items[n]);
            if (!result)
            {
                cmd = new string[] { "error", "-3" };
                return cmd[0];
            }
            Console.WriteLine("Item deleted.");
            return "view";
        }

        private static string RunChange(Order order)
        {
            items = order.Items();
            int n = Index(cmd[0]);
            if (n < 0)
                return cmd[0];
            if (cmd.Length < 3)
            {
                cmd = new string[] { "error", "-4" };
                return cmd[0];
            }

            int q = 0;
            try
            {
                q = int.Parse(cmd[2]);
                if (q == 0)
                {
                    cmd = new string[] { "error", "-5" };
                    return cmd[0];
                }
                bool result = order.ChangeQty(items[n], q);
                if (!result)
                {
                    cmd = new string[] { "error", "-3" };
                    return cmd[0];
                }
                Console.WriteLine("Quantity changed.");
                return "view";
            }
            catch
            {
                cmd = new string[] { "error", "-1" };
                return cmd[0];
            }
        }

        private static int Index(string ind)
        {
            try
            {
                int n = int.Parse(ind);
                if (n < 1 || n > items.Length)
                {
                    cmd = new string[] { "error", "-2" };
                    return -2;
                }
                return n - 1;
            }
            catch
            {
                cmd = new string[] { "error", "-1" };
                return -1;
            }
        }

        private static string RunError(string error)
        {
            int e = int.Parse(error);
            switch (e)
            {
                case -1:
                    Console.WriteLine("You have entered an invalid number.");
                    break;
                case -2:
                    Console.WriteLine("The number you entered is not on your order.");
                    break;
                case -3:
                    Console.WriteLine("I could not perform the operation. Please try again.");
                    break;
                case -4:
                    Console.WriteLine("You did not provide a quantity.");
                    break;
                case -5:
                    Console.WriteLine("You entered 0. If you wish to delete this item, you should use the delete command, please.");
                    break;
                default:
                    Console.WriteLine("Uh, something is wrong...Please try again.");
                    break;
            }
            return "view";
        }
    }
}