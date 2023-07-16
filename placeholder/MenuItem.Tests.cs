using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        [DataRow("bread", "whitebread", 5, 2, 1, 5)]
        [DataRow("bread", "whitebread", 5, 2, 3, 10)]
        [DataRow("pastry", "bun", 2, 3, 1, 2)]
        [DataRow("pastry", "bun", 2, 3, 4, 6)]
        public void getItem(string product, string option, int cost, int deal, int qty, int expected)
        {
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.Quantity = qty;
            int result = item.GetSubtotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "whitebread", 5, 2, "american", 1, "Whitebread - american                  1  $5")]
        [DataRow("bread", "whitebread", 5, 2, "american", 3, "Whitebread - american                  3  $10")]
        [DataRow("pastry", "bun", 2, 3, "spanish", 1, "Bun - spanish                           1  $2")]
        [DataRow("pastry", "bun", 2, 3, "spanish", 4, "Bun - spanish                           1  $6")]
        public void getItem(string product, string option, int cost, int deal, string variety, int qty, string expected)
        {
            MenuItem item = new MenuItem(product, option, cost, deal);
            item.ItemVariety = variety;
            item.Quantity = qty;
            string result = item.GetItem();
            Assert.AreEqual(expected, result);
        }
    }
}