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
    }
}