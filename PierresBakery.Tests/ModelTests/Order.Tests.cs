using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [DataRow("ryebread", "finnish", 1, "ryebread-finnish", true)]
        [DataRow("ryebread", "finnish", 1, "ryebread-chilean", false)]
        [DataRow("ryebread", "finnish", 1, "whitebread-finnish", false)]
        public void AddItem_AddEntryToOrder_Bool(string option, string variety, int qty, string key, bool expected)
        {
            Order order = new Order();
            MenuItem item = new Bread(option, variety, qty);
            order.AddItem(item);
            bool result = order.HasItem(key);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ryebread", "american", 1, "ryebread-american", true)]
        [DataRow("ryebread", "american", 1, "whitebread-american", false)]
        public void DeleteItem_DeleteEntryFromOrder_Bool(string option, string variety, int qty, string key, bool expected)
        {
            Order order = new Order();
            MenuItem item = new Bread(option, variety, qty);
            order.AddItem(item);
            bool result = order.DeleteItem(key);
            Assert.AreEqual(expected, result);
            Assert.IsFalse(order.HasItem(key));
        }

        [TestMethod]
        [DataRow("ryebread", "icelandic", 1, "ryebread-icelandic", 3, true)]
        [DataRow("ryebread", "icelandic", 1, "whitebread-icelandic", 2, false)]
        public void ChangeQty_ChangeQuantityOfItem_Bool(string option, string variety, int qty, string key, int diff, bool expected)
        {
            Order order = new Order();
            MenuItem item = new Bread(option, variety, qty);
            order.AddItem(item);
            bool result = order.ChangeQty(key, diff);
            Assert.AreEqual(expected, result);
        }

        /* No items */
        [TestMethod]
        public void Items_ReturnNoItemsInOrder_StringArray()
        {
            Order order = new Order();
            string[] expected = new string[0];
            CollectionAssert.AreEqual(expected, order.Items());
        }

        /* Single item */
        [TestMethod]
        public void Items_ReturnItemOfOrder_StringArray()
        {
            Order order = new Order();
            MenuItem item = new Bread("ryebread", "finnish", 1);
            order.AddItem(item);

            string key = $"{item.Option}-{item.Variety}";
            string[] expected = new string[] { key };
            CollectionAssert.AreEqual(expected, order.Items());
        }

        /* Multiple items */
        [TestMethod]
        public void Items_ReturnItemsOfOrder_StringArray()
        {
            Order order = new Order();
            MenuItem itemA = new Bread("sourdough", "german", 1);
            order.AddItem(itemA);

            MenuItem itemB = new Pastry("custard", "french", 1);
            order.AddItem(itemB);

            string keyA = $"{itemA.Option}-{itemA.Variety}";
            string keyB = $"{itemB.Option}-{itemB.Variety}";
            string[] expected = new string[] { keyA, keyB };
            CollectionAssert.AreEqual(expected, order.Items());
        }

        /* No items */
        [TestMethod]
        public void Receipt_ReturnNoFormattedItemInOrder_StringArray()
        {
            Order order = new Order();
            string[] result = new string[] {
                "--------------------------------------------------",
                "You have nothing in your order.",
                "--------------------------------------------------"
            };
            CollectionAssert.AreEqual(result, order.Receipt());
        }

        /* Single item */
        [TestMethod]
        public void Receipt_ReturnFormattedItemOfOrder_StringArray()
        {
            Order order = new Order();
            MenuItem bread = new Bread("ryebread", "icelandic", 1);
            order.AddItem(bread);

            string[] expected = new string[] {
                "--------------------------------------------------",
                "1. Ryebread - icelandic                    1  $8",
                "--------------------------------------------------",
                "Total                                         $8",
                "--------------------------------------------------"
            };
            string[] result = order.Receipt();
            CollectionAssert.AreEqual(expected, result);
        }

        /* Multiple items */
        [TestMethod]
        public void Receipt_ReturnFormattedItemsOfOrder_StringArray()
        {
            Order order = new Order();
            MenuItem bread = new Bread("ryebread", "icelandic", 1);
            order.AddItem(bread);
            MenuItem pastry = new Pastry("custard", "french", 7);
            order.AddItem(pastry);

            string[] expected = new string[] {
                "--------------------------------------------------",
                "1. Ryebread - icelandic                    1  $8",
                "2. Custard - french                        7  $18",
                "--------------------------------------------------",
                "Total                                         $26",
                "--------------------------------------------------"
            };
            string[] result = order.Receipt();
            Assert.AreEqual(expected[4], result[4]);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}