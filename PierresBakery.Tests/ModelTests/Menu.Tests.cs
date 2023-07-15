using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using PierresBakery.Models;

namespace PierresBakery.Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        [DataRow("bread", "flatbread", true)]
        [DataRow("bread", "baguette", false)]
        [DataRow("pastry", "custard", true)]
        [DataRow("pastry", "tart", false)]
        [DataRow("cheesecake", "custard", false)]
        public void hasOption_ReturnMenuHasOption_Bool(string product, string option, bool expected)
        {
            bool result = Menu.HasOption(product, option);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("sourdough", "italian", true)]
        [DataRow("sourdough", "dutch", false)]
        [DataRow("whitebread", "portuguese", false)]
        [DataRow("custard", "japanese", true)]
        [DataRow("strudel", "american", false)]
        [DataRow("bread", "portuguese", true)]
        [DataRow("bread", "chinese", false)]
        [DataRow("pastry", "filipino", true)]
        [DataRow("pastry", "mexican", false)]
        public void hasVariety_ReturnMenuHasVariety_Bool(string option, string variety, bool expected)
        {
            bool result = Menu.HasVariety(option, variety);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread", "ryebread, flatbread, sourdough, and special")]
        [DataRow("pastry", "custard, macaroon, strudel, and special")]
        [DataRow("pie", "")]
        public void getOptions_ReturnOptionsOfProduct_String(string product, string expected)
        {
            string result = Menu.GetOptions(product);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ryebread", "icelandic and finnish")]
        [DataRow("strudel", "austrian, turkish, and hungarian")]
        [DataRow("baguette", "")]
        public void getVarieties_ReturnVarietiesOfOption_String(string option, string expected)
        {
            string result = Menu.GetVarieties(option);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("bread")]
        [DataRow("pastry")]
        public void getVarieties_ReturnVarietiesOfSpecial_String(string product)
        {
            string[] varieties = Menu.GetVarieties(product, "special").Split(" and ");
            Assert.IsTrue(Menu.HasVariety(product, varieties[0]));
            Assert.IsTrue(Menu.HasVariety(product, varieties[1]));
        }
    }
}