using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests;

[TestClass]
public class MenuTests
{
    [TestMethod]
    [DataRow("bread", true)]
    [DataRow("cake", false)]
    public void HasProduct_ReturnMenuHasProduct_Bool(string product, bool expected)
    {
        bool result = Menu.HasProduct(product);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("bread", "bread", true)]
    [DataRow("bread", "ryebread", true)]
    [DataRow("bread", "whitebread", false)]
    [DataRow("pastry", "pastry", true)]
    [DataRow("pastry", "custard", true)]
    [DataRow("pastry", "bun", false)]
    public void HasOption_ReturnMenuHasProductOption_Bool(string product, string option, bool expected)
    {
        bool result = Menu.HasOption(product, option);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("bread", 0, "american", true)]
    [DataRow("pastry", 3, "turkish", true)]
    public void HasVariety_ReturnMenuHasProductOptionVariety_Bool(string product, int optionId, string variety, bool expected)
    {
        bool result = Menu.HasVariety(product, optionId, variety);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    [DataRow("bread", "ryebread", 1)]
    [DataRow("pastry", "strudel", 3)]
    [DataRow("cake", "custard", -1)]
    [DataRow("bread", "whitebread", -1)]
    public void Find_ReturnIdOfFoundObject_Int(string product, string option, int expected)
    {
        int result = Menu.Find(product, option);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Options_ReturnOptionsOfMenuProduct_StringArray()
    {
        string product = "pastry";
        string[] expected = new string[] { "pastry", "custard", "macaroon", "strudel" };
        string[] result = Menu.Options(product);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("bread", 1, new string[] { "icelandic", "finnish" })]
    [DataRow("pastry", 0, new string[] { "filipino", "austrian", "portuguese", "french" })]
    public void Varieties_ReturnVarietiesOfOption_StringArray(string product, int optionId, string[] expected)
    {
        string[] result = Menu.Varieties(product, optionId);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("bread", 2, 6)]
    [DataRow("pastry", 1, 3)]
    public void Cost_ReturnCostOfOption_Int(string product, int optionId, int expected)
    {
        int result = Menu.Cost(product, optionId);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("bread", 3, 2)]
    [DataRow("pastry", 2, 8)]
    public void Deal_ReturnDealOfOption_Int(string product, int optionId, int expected)
    {
        int result = Menu.Deal(product, optionId);
        Assert.AreEqual(expected, result);
    }
}
