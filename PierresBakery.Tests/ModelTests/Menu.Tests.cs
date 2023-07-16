using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        [DataRow("bread", "bread", true)]
        [DataRow("bread", "ryebread", true)]
        [DataRow("ryebread", "bread", false)]
        [DataRow("bread", "whitebread", false)]
        [DataRow("pastry", "pastry", true)]
        [DataRow("pastry", "custard", true)]
        [DataRow("custard", "pastry", false)]
        [DataRow("pastry", "bun", false)]
        public void HasOption_ReturnMenuHasProductOption_Bool(string product, string option, bool expected)
        {
            bool result = Menu.HasOption(product, option);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "american", true)]
        [DataRow("ryebread", "spanish", false)]
        [DataRow("whitebread", "bread", false)]
        public void HasVariety_ReturnMenuHasOptionVariety_Bool(string option, string variety, bool expected)
        {
            bool result = Menu.HasVariety(option, variety);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "ryebread, flatbread, sourdough, and bread")]
        [DataRow("pastry", "custard, macaroon, strudel, and pastry")]
        [DataRow("cake", "")]
        public void Options_ReturnOptionsOfProduct_String(string product, string expected)
        {
            string result = Menu.Options(product);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ryebread", "icelandic and finnish")]
        [DataRow("pastry", "filipino, austrian, portuguese, and french")]
        [DataRow("cake", "")]
        public void Varieties_ReturnVarietiesOfOption_String(string option, string expected)
        {
            string result = Menu.Varieties(option);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("flatbread", 6)]
        [DataRow("whitebread", -1)]
        public void Cost_ReturnCostOfOption_Int(string option, int expected)
        {
            int result = Menu.Cost(option);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("macaroon", 8)]
        [DataRow("pie", -1)]
        public void Deal_ReturnDealOfOption_Int(string option, int expected)
        {
            int result = Menu.Deal(option);
            Assert.AreEqual(expected, result);
        }
    }
}