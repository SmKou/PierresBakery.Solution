using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class BreadTests
{
    [TestMethod]
    public void Bread_CreateBreadObject_Void()
    {
        Item test = new Bread();

        Assert.AreEqual(typeof(Bread), test.GetType());
        Assert.AreEqual("bread", test.Product);
    }

    [TestMethod]
    [DataRow("bread", "american", 2, 10)]
    [DataRow("ryebread", "icelandic", 1, 8)]
    [DataRow("flatbread", "italian", 5, 24)]
    public void Total_ReturnCostOfBread_Int(string option, string variety, int qty, int expected)
    {
        Item test = new Bread();
        test.Option = option;
        test.OptionId = Menu.Find(test.Product, test.Option);
        test.Quantity = qty;

        int result = test.Total();

        Assert.AreEqual(expected, result);
    }
}

