using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Code_Assignment;


namespace AssignmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckPromotionsCorrect()
        {
            Dictionary<string, double> testProducts = new Dictionary<string, double>()
            {
                { "headstone", 1 },
                { "base", 1 },
            };
            string expected = "Headstone 10% off-2 dowels for half price-";
            string actual = Program.CheckPromotions(testProducts);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CheckPromotionsFail()
        {
            Dictionary<string, double> testProducts = new Dictionary<string, double>()
            {
                { "headstone", 1 },
                { "base", 1 },
            };
            string expected = "Headstone 1% off-2 dowels for half price-";
            string actual = Program.CheckPromotions(testProducts);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CalculateSumCorrect()
        {
            Dictionary<string, double> basket = new Dictionary<string, double>()
            {
                { "headstone", 1 },
                { "base", 1 },
                { "dowel", 2 },
                { "vase", 0 }
            };
            double expected = 173;
            double actual = Program.CalculateSum(Program.ApplyPromotions(Program.CheckPromotions(basket), basket));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSumFail()
        {
            Dictionary<string, double> basket = new Dictionary<string, double>()
            {
                { "headstone", 1 },
                { "base", 1 },
                { "dowel", 2 },
                { "vase", 0 }
            };
            double expected = 170;
            double actual = Program.CalculateSum(Program.ApplyPromotions(Program.CheckPromotions(basket), basket));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMain()
        {
            string[] shoppingList = new string[] { "headstone", "base" };
            string expected = "Subtotal: £180\nHeadstone 10 % off: -£12\nTotal: £168";
            string actual = Program.MainMethod(shoppingList);
            
            Assert.AreEqual(expected, actual);
        }
    }
}
