using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class PastryTests
    {
        [TestMethod]
        [DataRow("special", 2, 3)]
        [DataRow("custard", 3, 6)]
        [DataRow("macaroon", 1, 8)]
        [DataRow("strudel", 5, 3)]
        public void pastry_CreatePastryObject_Pastry(string option, int expected_cost, int expected_deal)
        {
            MenuItem pastry = new Pastry(option);
            Assert.AreEqual(expected_cost, pastry.Cost);
            Assert.AreEqual(expected_deal, pastry.DealAmount);
        }

        [TestMethod]
        [DataRow("custard", "french", 1, "Custard - french                        1  $3")]
        [DataRow("custard", "french", 7, "Custard - french                        7  $18")]
        [DataRow("macaroon", "filipino", 1, "Macaroon - filipino                     1  $1")]
        [DataRow("macaroon", "filipino", 9, "Macaroon - filipino                     9  $8")]
        [DataRow("strudel", "turkish", 1, "Strudel - turkish                       1  $5")]
        [DataRow("strudel", "turkish", 4, "Strudel - turkish                       4  $15")]
        public void getItem_ReturnItemInformation_String(string option, string variety, int qty, string expected)
        {
            MenuItem pastry = new Pastry(option);
            pastry.ItemVariety = variety;
            pastry.Quantity = qty;
            string result = pastry.GetItem();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("special", 2)]
        [DataRow("custard", 3)]
        [DataRow("macaroon", 1)]
        [DataRow("strudel", 5)]
        public void itemCost_ReturnCostOfPastry_Int(string option, int expected_cost)
        {
            int result = Pastry.ItemCost(option);
            Assert.AreEqual(expected_cost, result);
        }

        [TestMethod]
        [DataRow("special", 3)]
        [DataRow("custard", 6)]
        [DataRow("macaroon", 8)]
        [DataRow("strudel", 3)]
        public void itemDeal_ReturnDealForPastry_Int(string option, int expected_deal)
        {
            int result = Pastry.ItemDeal(option);
            Assert.AreEqual(expected_deal, result);
        }
    }
}