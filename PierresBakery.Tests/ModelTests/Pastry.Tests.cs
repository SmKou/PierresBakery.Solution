using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class PastryTests
    {
        [TestMethod]
        [DataRow("pastry", "austrian", 2)]
        [DataRow("strudel", "hungarian", 3)]
        public void Pastry_CreatePastryObject_Pastry(string option, string variety, int qty)
        {
            MenuItem pastry = new Pastry(option, variety, qty);
            Assert.AreEqual("pastry", pastry.Product);
            Assert.AreEqual(option, pastry.Option);
            Assert.AreEqual(variety, pastry.Variety);
            Assert.AreEqual(qty, pastry.Quantity);
        }

        [TestMethod]
        [DataRow("pastry", "french", 2, 4)]
        [DataRow("custard", "japanese", 1, 3)]
        [DataRow("macaroon", "french", 9, 8)]
        public void Total_ReturnCostOfPastry_Int(string option, string variety, int qty, int expected)
        {
            MenuItem pastry = new Pastry(option, variety, qty);
            int result = pastry.Total();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("custard", "french", 1, "Custard - french                        1  $3")]
        [DataRow("custard", "french", 7, "Custard - french                        7  $18")]
        [DataRow("macaroon", "filipino", 1, "Macaroon - filipino                     1  $1")]
        [DataRow("macaroon", "filipino", 9, "Macaroon - filipino                     9  $8")]
        [DataRow("strudel", "turkish", 1, "Strudel - turkish                       1  $5")]
        [DataRow("strudel", "turkish", 4, "Strudel - turkish                       4  $15")]
        public void Item_ReturnItemInformation_String(string option, string variety, int qty, string expected)
        {
            MenuItem pastry = new Pastry(option, variety, qty);
            string result = pastry.Item();
            Assert.AreEqual(expected, result);
        }
    }
}