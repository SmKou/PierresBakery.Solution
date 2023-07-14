using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class BreadTests
    {
        [TestMethod]
        [DataRow("rye", "ryebread", 8)]
        [DataRow("ryebread", "ryebread", 8)]
        [DataRow("flat", "flatbread", 6)]
        [DataRow("flatbread", "flatbread", 6)]
        [DataRow("sour", "sourdough", 7)]
        [DataRow("sourdough", "sourdough", 7)]
        [DataRow("special", "special", 5)]
        public void bread_ConstructMenuItem_Void(string type, string expected_type, int expected)
        {
            MenuItem bread = MenuItem.makeBread(type);
            Assert.AreEqual("bread", bread.ItemName);
            Assert.AreEqual(expected_type, bread.Type);
            Assert.AreEqual(expected, bread.Cost);
        }

        [TestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 10)]
        [DataRow(3, 10)]
        [DataRow(4, 15)]
        public void bread_ReturnSubtotalOfBread_Int(int amt, int total)
        {
            string type = "special";
            MenuItem bread = MenuItem.makeBread(type);
            int result = bread.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        [DataRow()]
        public void bread_ReturnOriginsList_StringArray()
        { }

        [TestMethod]
        [DataRow()]
        public void bread_ReturnListContainsItem_Int()
        {}

        [TestMethod]
        [DataRow()]
        public void bread_ReturnCapitalizedOrigin_String()
        {}
    }
}