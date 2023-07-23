using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class OrderTests
{
    [TestMethod]
    public void IsEmpty_ReturnOrderIsEmpty_Bool()
    {
        Order.ClearAll();
        bool result = Order.IsEmpty();
        Assert.IsTrue(result);
    }

    [TestMethod]
    [DataRow("ryebread", "finnish", 1, "ryebread-finnish", true)]
    [DataRow("ryebread", "finnish", 1, "whitebread-finnish", false)]
    public void HasandAddItem_AddItemToOrder_ReturnOrderHasItem_Bool(string option, string variety, int qty, string itemName, bool expected)
    {
        Item test = new Bread(option, variety, qty);
        Order.AddItem(test);
        bool result = Order.Has(itemName);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("ryebread-finnish", 3, true)]
    [DataRow("whitebread-icelandic", 2, false)]
    public void ChangeQty_ChangeQuantityOfItem_Bool(string itemName, int chg, bool expected)
    {
        bool result = Order.ChangeQty(itemName, chg);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Items_ReturnListOfItemsInOrder_ItemArray()
    {
        Item expected = new Bread("ryebread", "finnish", 3);
        Item result = Order.Items()[0];
        Assert.AreEqual(expected.Product, result.Product);
        Assert.AreEqual(expected.Option, result.Option);
        Assert.AreEqual(expected.OptionId, result.OptionId);
        Assert.AreEqual(expected.Variety, result.Variety);
        Assert.AreEqual(expected.Quantity, result.Quantity);
    }

    [TestMethod]
    public void Total_ReturnTotalCostOfOrder_Int()
    {
        int expected = 16;
        int result = Order.Total();
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("whitebread-american", false)]
    [DataRow("ryebread-finnish", true)]
    public void DeleteItem_RemoveItemFromOrder_Bool(string itemName, bool expected)
    {
        bool result = Order.DeleteItem(itemName);
        Assert.AreEqual(expected, result);
        Assert.IsFalse(Order.Has(itemName));
    }
}
