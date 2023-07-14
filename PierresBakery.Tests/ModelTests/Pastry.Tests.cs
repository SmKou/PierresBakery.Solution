using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class PastryTests
    {
        [TestMethod]
        [DataRow("special", "special", 2)]
        public void pastry_ConstructMenuItem_Void(string type, string expected_type, int expected)
        {
            MenuItem pastry = MenuItem.makePastry(type);
            Assert.AreEqual("pastry", pastry.ItemName);
            Assert.AreEqual(expected_type, pastry.Type);
            Assert.AreEqual(expected, pastry.Cost);
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 4)]
        [DataRow(3, 6)]
        [DataRow(4, 6)]
        [DataRow(5, 8)]
        public void pastry_ReturnSubtotalOfBread_Int(int amt, int total)
        {
            MenuItem pastry = MenuItem.makePastry("special");
            int result = pastry.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }
    }
}