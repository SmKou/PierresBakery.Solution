using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "whitebread-american", true)]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "ryebread-american", false)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "bun-chilean", true)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "cookie-chilean", false)]
        public void addItem_AddEntryToOrder_Bool(string product, string option, string variety, int cost, int deal, int qty, string key, bool expected)
        {
            Order order = new Order();
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.ItemVariety = variety;
            item.Quantity = qty;
            order.AddItem($"{item.ItemOption}-{item.ItemVariety}", item);
            bool result = order.HasItem(key);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "whitebread-american", true)]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "ryebread-american", false)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "bun-chilean", true)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "cookie-chilean", false)]
        public void deleteItem_DeleteEntryFromOrder_Bool(string product, string option, string variety, int cost, int deal, int qty, string key, bool expected)
        {
            Order order = new Order();
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.ItemVariety = variety;
            item.Quantity = qty;
            order.AddItem($"{item.ItemOption}-{item.ItemVariety}", item);
            bool result = order.DeleteItem(key);
            Assert.AreEqual(expected, result);
            Assert.IsFalse(order.HasItem(key));
        }

        [TestMethod]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "whitebread-american", 3, true)]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "ryebread-american", 2, false)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "bun-chilean", 4, true)]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "cookie-chilean", 5, false)]
        public void changeQty_ChangeQuantityOfItem_Bool(string product, string option, string variety, int cost, int deal, int qty, string key, int diff, bool expected)
        {
            Order order = new Order();
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.ItemVariety = variety;
            item.Quantity = qty;
            order.AddItem($"{item.ItemOption}-{item.ItemVariety}", item);
            bool result = order.ChangeQty(key, diff);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "whitebread", "american", 5, 2, 1, "whitebread-american")]
        [DataRow("pastry", "bun", "chilean", 2, 3, 1, "bun-chilean")]
        public void getItems_ReturnItemsOfOrder_StringArray(string product, string option, string variety, int cost, int deal, int qty, string key)
        {
            string[] expected = new string[] { key };
            Order order = new Order();
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.ItemVariety = variety;
            item.Quantity = qty;
            order.AddItem($"{item.ItemOption}-{item.ItemVariety}", item);
            CollectionAssert.AreEqual(expected, order.GetItems());
        }
    }
}