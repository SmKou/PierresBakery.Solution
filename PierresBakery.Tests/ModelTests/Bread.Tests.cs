using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class BreadTests
    {
        [TestMethod]
        [DataRow("bread", "american", 2)]
        [DataRow("ryebread", "icelandic", 1)]
        public void Bread_CreateBreadObject_Bread(string option, string variety, int qty)
        {
            MenuItem bread = new Bread(option, variety, qty);
            Assert.AreEqual("bread", bread.Product);
            Assert.AreEqual(option, bread.Option);
            Assert.AreEqual(variety, bread.Variety);
            Assert.AreEqual(qty, bread.Quantity);
        }

        [TestMethod]
        [DataRow("bread", "american", 2, 10)]
        [DataRow("ryebread", "icelandic", 1, 8)]
        [DataRow("flatbread", "italian", 5, 24)]
        public void Total_ReturnCostOfBread_Int(string option, string variety, int qty, int expected)
        {
            MenuItem bread = new Bread(option, variety, qty);
            int result = bread.Total();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ryebread", "icelandic", 1, "Ryebread - icelandic                    1  $8")]
        [DataRow("ryebread", "icelandic", 3, "Ryebread - icelandic                    3  $16")]
        [DataRow("flatbread", "middle eastern", 1, "Flatbread - middle eastern              1  $6")]
        [DataRow("flatbread", "middle eastern", 5, "Flatbread - middle eastern              5  $24")]
        [DataRow("sourdough", "german", 1, "Sourdough - german                      1  $7")]
        [DataRow("sourdough", "german", 3, "Sourdough - german                      3  $14")]
        public void Item_ReturnItemInformation_String(string option, string variety, int qty, string expected)
        {
            MenuItem bread = new Bread(option, variety, qty);
            string result = bread.Item();
            Assert.AreEqual(expected, result);
        }
    }
}
