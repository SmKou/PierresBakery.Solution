using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class BreadTests
    {
        [TestMethod]
        [DataRow("special", 5, 2)]
        [DataRow("ryebread", 8, 2)]
        [DataRow("flatbread", 6, 4)]
        [DataRow("sourdough", 7, 2)]
        public void bread_CreateBreadObject_Bread(string option, int expected_cost, int expected_deal)
        {
            MenuItem bread = new Bread(option);
            Assert.AreEqual(expected_cost, bread.Cost);
            Assert.AreEqual(expected_deal, bread.DealAmount);
        }

        [TestMethod]
        [DataRow("ryebread", "icelandic", 1, "Ryebread - icelandic                    1  $8")]
        [DataRow("ryebread", "icelandic", 3, "Ryebread - icelandic                    3  $16")]
        [DataRow("flatbread", "middle eastern", 1, "Flatbread - middle eastern              1  $6")]
        [DataRow("flatbread", "middle eastern", 5, "Flatbread - middle eastern              5  $24")]
        [DataRow("sourdough", "german", 1, "Sourdough - german                      1  $7")]
        [DataRow("sourdough", "german", 3, "Sourdough - german                      3  $14")]
        public void getItem_ReturnItemInformation_String(string option, string variety, int qty, string expected)
        {
            MenuItem bread = new Bread(option);
            bread.ItemVariety = variety;
            bread.Quantity = qty;
            string result = bread.GetItem();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("special", 5)]
        [DataRow("ryebread", 8)]
        [DataRow("flatbread", 6)]
        [DataRow("sourdough", 7)]
        [DataRow("baguette", 0)]
        public void itemCost_ReturnCostOfBread_Int(string option, int expected_cost)
        {
            int result = Bread.ItemCost(option);
            Assert.AreEqual(expected_cost, result);
        }

        [TestMethod]
        [DataRow("special", 2)]
        [DataRow("ryebread", 2)]
        [DataRow("flatbread", 4)]
        [DataRow("sourdough", 2)]
        [DataRow("baguette", 0)]
        public void itemDeal_ReturnDealForBread_Int(string option, int expected_deal)
        {
            int result = Bread.ItemDeal(option);
            Assert.AreEqual(expected_deal, result);
        }
    }
}
