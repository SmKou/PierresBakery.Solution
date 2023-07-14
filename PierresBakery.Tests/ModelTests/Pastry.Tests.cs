using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class PastryTests
    {
        [TestMethod]
        [DataRow("strudel", "strudel", 5)]
        [DataRow("macaroon", "macaroon", 1)]
        [DataRow("macaron", "macaroon", 1)]
        [DataRow("custard", "custard", 3)]
        [DataRow("special", "special", 2)]
        public void pastry_ConstructMenuItem_Void(string type, string expected_type, int expected)
        {
            MenuItem pastry = MenuItem.makePastry(type);
            Assert.AreEqual("pastry", pastry.ItemName);
            Assert.AreEqual(expected_type, pastry.Type);
            Assert.AreEqual(expected, pastry.Cost);
        }

        [TestMethod]
        [DataRow("custard", 1, 3)]
        [DataRow("custard", 2, 6)]
        [DataRow("custard", 6, 18)]
        [DataRow("custard", 7, 18)]
        [DataRow("custard", 14, 36)]
        [DataRow("macaron", 1, 1)]
        [DataRow("macaron", 2, 2)]
        [DataRow("macaron", 8, 8)]
        [DataRow("macaron", 9, 8)]
        [DataRow("macaron", 18, 16)]
        [DataRow("strudel", 1, 5)]
        [DataRow("strudel", 2, 10)]
        [DataRow("strudel", 3, 15)]
        [DataRow("strudel", 4, 15)]
        [DataRow("strudel", 8, 30)]
        [DataRow("special", 1, 2)]
        [DataRow("special", 2, 4)]
        [DataRow("special", 3, 6)]
        [DataRow("special", 4, 6)]
        [DataRow("special", 8, 12)]
        public void pastry_ReturnSubtotalOfPastry_Int(string type, int amt, int total)
        {
            MenuItem pastry = MenuItem.makePastry(type);
            int result = pastry.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        [DataRow()]
        public void pastry_ReturnOriginsList_StringArray()
        { }

        [TestMethod]
        [DataRow()]
        public void pastry_ReturnListContainsItem_Int()
        { }

        [TestMethod]
        [DataRow()]
        public void pastry_ReturnCapitalizedOrigin_String()
        { }
    }
}