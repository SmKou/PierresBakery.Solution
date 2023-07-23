using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class FormatTests
{
    public void Dispose()
    {
        Order.ClearAll();
    }

    [TestMethod]
    public void List_ReturnFormattedListOfOrderItems_String()
    {
        string[] options = Menu.Options("bread");
        string expected = "bread, ryebread, flatbread, and sourdough";

        string result = Format.List(options);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void OrderList_ReturnFormattedListForNoItems_StringArray()
    {
        Item[] items = Order.Items();
        string[] expected = new string[] {
            "------------------------------------------------------",
            "You have no items in your order.",
            "------------------------------------------------------"
        };
        string[] result = Format.OrderList(items);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void OrderList_ReturnFormattedListOfItemsAndOrderCost_StringArray()
    {
        Item test = new Bread("ryebread", "finnish", 1);
        Order.AddItem(test);
        Item[] items = Order.Items();
        string[] expected = new string[] {
            "------------------------------------------------------",
            "1.   Ryebread - finnish                      1    $8",
            "------------------------------------------------------",
            "Total                                             $8",
            "------------------------------------------------------"
        };
        string[] result = Format.OrderList(items);
        Assert.AreEqual(expected[1], result[1]);
        CollectionAssert.AreEqual(expected, result);
    }
}