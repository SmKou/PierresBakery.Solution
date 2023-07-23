using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class BreadTests
{
    [TestMethod]
    [DataRow("bread", "american", 2, 0)]
    [DataRow("ryebread", "icelandic", 1, 1)]
    public void Bread_CreateBreadObject_Void(string option, string variety, int qty, int expected)
    {
        Item test = new Bread(option, variety, qty);

        Assert.AreEqual(typeof(Bread), test.GetType());
        Assert.AreEqual("bread", test.Product);
    }

    [TestMethod]
    [DataRow("bread", "american", 2, 10)]
    [DataRow("ryebread", "icelandic", 1, 8)]
    [DataRow("flatbread", "italian", 5, 24)]
    public void Total_ReturnCostOfBread_Int(string option, string variety, int qty, int expected)
    {
        Item test = new Bread(option, variety, qty);

        int result = test.Total();

        Assert.AreEqual(expected, result);
    }
}

