using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class PierresBakeryTest
    {
        [TestMethod]
        public void bread_ConstructMenuItem_Void()
        {
            MenuItem bread = new Bread();
            Assert.AreEqual("bread", bread.ItemName);
            Assert.AreEqual(5, bread.Cost);
            Assert.AreEqual(2, bread.DealAmount);
        }

        [TestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 10)]
        [DataRow(3, 10)]
        [DataRow(4, 15)]
        public void bread_ReturnSubtotalOfBread_Int(int amt, int total)
        {
            MenuItem bread = new Bread();
            int result = bread.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }

        [TestMethod]
        public void pastry_ConstructMenuItem_Void()
        {
            MenuItem pastry = new Pastry();
            Assert.AreEqual("pastry", pastry.ItemName);
            Assert.AreEqual(2, pastry.Cost);
            Assert.AreEqual(3, pastry.DealAmount);
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 4)]
        [DataRow(3, 6)]
        [DataRow(4, 6)]
        [DataRow(5, 8)]
        public void pastry_ReturnSubtotalOfBread_Int(int amt, int total)
        {
            MenuItem pastry = new Pastry();
            int result = pastry.GetSubtotal(amt);
            Assert.AreEqual(total, result);
        }
    }
}