using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart.Tests
{
    [TestClass()]
    public class PotterCalculatorTests
    {
        [TestMethod()]
        public void CalculatorTest_第一集買了一本其他都沒買價格應為100元()
        {
            // arragne
            var target = new PotterCalculator();
            var buyList = new HarryPotter { Vol_1 = 1, Vol_2 = 0, Vol_3 = 0, Vol_4 = 0, Vol_5 = 0 };
            double expected = 100;

            // act
            double amount = target.Calculator(buyList);

            // assert
            Assert.AreEqual(expected, amount);
        }

        [TestMethod()]
        public void CalculatorTest_第一集一本第二集也一本價格應為190()
        {
            // arragne
            var target = new PotterCalculator();
            var buyList = new HarryPotter { Vol_1 = 1, Vol_2 = 1, Vol_3 = 0, Vol_4 = 0, Vol_5 = 0 };
            double expected = 190;

            // act
            double amount = target.Calculator(buyList);

            // assert
            Assert.AreEqual(expected, amount);
        }

        [TestMethod()]
        public void CalculatorTest_一二三集各買了一本價格應為270()
        {
            // arragne
            var target = new PotterCalculator();
            var buyList = new HarryPotter { Vol_1 = 1, Vol_2 = 1, Vol_3 = 1, Vol_4 = 0, Vol_5 = 0 };
            double expected = 270;

            // act
            double amount = target.Calculator(buyList);

            // assert
            Assert.AreEqual(expected, amount);
        }

        [TestMethod()]
        public void CalculatorTest_一二三四集各買了一本價格應為320()
        {
            // arragne
            var target = new PotterCalculator();
            var buyList = new HarryPotter { Vol_1 = 1, Vol_2 = 1, Vol_3 = 1, Vol_4 = 1, Vol_5 = 0 };
            double expected = 320;

            // act
            double amount = target.Calculator(buyList);

            // assert
            Assert.AreEqual(expected, amount);
        }
    }
}