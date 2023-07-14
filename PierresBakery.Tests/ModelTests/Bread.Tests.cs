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
        [DataRow("rye", 1, 8)]
        [DataRow("rye", 2, 16)]
        [DataRow("rye", 3, 16)]
        [DataRow("rye", 6, 32)]
        [DataRow("flat", 1, 6)]
        [DataRow("flat", 2, 12)]
        [DataRow("flat", 4, 24)]
        [DataRow("flat", 5, 24)]
        [DataRow("flat", 10, 48)]
        [DataRow("sour", 1, 7)]
        [DataRow("sour", 2, 14)]
        [DataRow("sour", 3, 14)]
        [DataRow("sour", 6, 28)]
        [DataRow("special", 1, 5)]
        [DataRow("special", 2, 10)]
        [DataRow("special", 3, 10)]
        [DataRow("special", 6, 20)]
        public void bread_ReturnSubtotalOfBread_Int(string type, int amt, int total)
        {
            MenuItem bread = MenuItem.makeBread(type);
            int result = bread.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        [DataRow("rye", 2)]
        [DataRow("flat", 2)]
        [DataRow("sour", 3)]
        [DataRow("special", 1)]
        public void bread_ReturnOriginsList_StringArray(string type, int expected)
        {
            MenuItem bread = MenuItem.makeBread(type);
            Assert.AreEqual(expected, bread.Origins.Length);
        }

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