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
        public void pastry_ConstructMenuItem_Void()
        {
            MenuItem pastry = new Pastry();
            Assert.AreEqual("pastry", pastry.ItemName);
            Assert.AreEqual(2, pastry.Cost);
            Assert.AreEqual(3, pastry.DealAmount);
        }
    }
}