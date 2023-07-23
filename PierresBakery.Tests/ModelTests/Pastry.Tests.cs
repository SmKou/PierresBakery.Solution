using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class PastryTests
{
    [TestMethod]
    [DataRow("pastry", "austrian", 2)]
    [DataRow("strudel", "hungarian", 3)]
    public void Pastry_CreatePastryObject_Void(string option, string variety, int qty)
    {
        Item test = new Pastry(option, variety, qty);

        Assert.AreEqual(typeof(Pastry), test.GetType());
        Assert.AreEqual("pastry", test.Product);
    }

    [TestMethod]
    [DataRow("pastry", "french", 2, 4)]
    [DataRow("custard", "japanese", 1, 3)]
    [DataRow("macaroon", "french", 9, 8)]
    public void Total_ReturnCostOfPastry_Int(string option, string variety, int qty, int expected)
    {
        Item test = new Pastry(option, variety, qty);

        int result = test.Total();

        Assert.AreEqual(expected, result);
    }
}
