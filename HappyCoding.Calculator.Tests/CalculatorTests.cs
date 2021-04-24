using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HappyCoding.Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void SimpleAddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1+4");
            Assert.AreEqual(5d, result);
        }

        [TestMethod]
        public void SimpleSubtractTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1-4");
            Assert.AreEqual(-3d, result);
        }

        [TestMethod]
        public void SimpleMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2*4");
            Assert.AreEqual(8d, result);
        }

        [TestMethod]
        public void SimpleDivideTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/4");
            Assert.AreEqual(0.5d, result);
        }

        [TestMethod]
        public void AddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1+4+9");
            Assert.AreEqual(14d, result);
        }

        [TestMethod]
        public void SubtractTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9-1-4");
            Assert.AreEqual(4d, result);
        }

        [TestMethod]
        public void MultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2*4*5");
            Assert.AreEqual(40d, result);
        }

        [TestMethod]
        public void DivideTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/4/2");
            Assert.AreEqual(0.25d, result);
        }

        [TestMethod]
        public void SubtractAndAddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9-1-4+4");
            Assert.AreEqual(8d, result);
        }

        [TestMethod]
        public void AddAndMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9+3*2");
            Assert.AreEqual(15d, result);
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void DivideByZeroTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/0");
        }

        [TestMethod]
        public void MultipleAndAddParenthesisTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("(9+3)*2");
            Assert.AreEqual(24d, result);
        }

        [TestMethod]
        public void MultipleAndAddNestedParenthesisTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("5*((9+3)*2)+4");
            Assert.AreEqual(124d, result);
        }

        [TestMethod]
        public void DivideAndMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("3/3*5");
            Assert.AreEqual(5d, result);
        }



        [TestMethod]
        public void ChallengeTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("(1+2)/3*5");
            Assert.AreEqual(5d, result);
        }


    }
}
