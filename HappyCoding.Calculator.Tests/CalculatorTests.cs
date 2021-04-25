// Copyright (c) Markus Meyer. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HappyCoding.Calculator.Tests
{
    /// <summary>
    /// CalculatorTests.
    /// </summary>
    [TestClass]
    public class CalculatorTests
    {
        /// <summary>
        /// Simples the add test.
        /// </summary>
        [TestMethod]
        public void SimpleAddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1+4");
            Assert.AreEqual(5d, result);
        }

        /// <summary>
        /// Simples the subtract test.
        /// </summary>
        [TestMethod]
        public void SimpleSubtractTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1-4");
            Assert.AreEqual(-3d, result);
        }

        /// <summary>
        /// Simples the multiple test.
        /// </summary>
        [TestMethod]
        public void SimpleMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2*4");
            Assert.AreEqual(8d, result);
        }

        /// <summary>
        /// Simples the divide test.
        /// </summary>
        [TestMethod]
        public void SimpleDivideTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/4");
            Assert.AreEqual(0.5d, result);
        }

        /// <summary>
        /// Adds the test.
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("1+4+9");
            Assert.AreEqual(14d, result);
        }

        /// <summary>
        /// Subtracts the test.
        /// </summary>
        [TestMethod]
        public void SubtractTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9-1-4");
            Assert.AreEqual(4d, result);
        }

        /// <summary>
        /// Multiples the test.
        /// </summary>
        [TestMethod]
        public void MultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2*4*5");
            Assert.AreEqual(40d, result);
        }

        /// <summary>
        /// Multiples the negative test.
        /// </summary>
        [TestMethod]
        public void MultipleNegativeTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2*4*-5");
            Assert.AreEqual(-40d, result);
        }

        /// <summary>
        /// Divides the test.
        /// </summary>
        [TestMethod]
        public void DivideTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/4/2");
            Assert.AreEqual(0.25d, result);
        }

        /// <summary>
        /// Subtracts the and add test.
        /// </summary>
        [TestMethod]
        public void SubtractAndAddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9-1-4+4");
            Assert.AreEqual(8d, result);
        }

        /// <summary>
        /// Adds the and multiple test.
        /// </summary>
        [TestMethod]
        public void AddAndMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9+3*2");
            Assert.AreEqual(15d, result);
        }

        /// <summary>
        /// Adds the and multiple and add test.
        /// </summary>
        [TestMethod]
        public void AddAndMultipleAndAddTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("9+3*2+4");
            Assert.AreEqual(19d, result);
        }

        /// <summary>
        /// Divides the by zero test.
        /// </summary>
        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void DivideByZeroTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("2/0");
        }

        /// <summary>
        /// Multiples the and add parenthesis test.
        /// </summary>
        [TestMethod]
        public void MultipleAndAddParenthesisTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("(9+3)*2");
            Assert.AreEqual(24d, result);
        }

        /// <summary>
        /// Multiples the and add nested parenthesis test.
        /// </summary>
        [TestMethod]
        public void MultipleAndAddNestedParenthesisTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("5*((9+3)*2)+4");
            Assert.AreEqual(124d, result);
        }

        /// <summary>
        /// Divides the and multiple test.
        /// </summary>
        [TestMethod]
        public void DivideAndMultipleTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("3/3*5");
            Assert.AreEqual(5d, result);
        }

        /// <summary>
        /// Challenges the test.
        /// </summary>
        [TestMethod]
        public void ChallengeTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("(1+2)/3*5");
            Assert.AreEqual(5d, result);
        }

        /// <summary>
        /// Validations the test.
        /// </summary>
        [TestMethod]
        public void ValidationTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.Calculate("(1+2)/3*5+");
            Assert.AreEqual(double.NaN, result);
        }

        /// <summary>
        /// Validations the method test.
        /// </summary>
        [TestMethod]
        public void ValidationMethodTest()
        {
            AdvancedCalculator advancedCalculator = new();
            var result = advancedCalculator.IsValidExpression("(1+2)/3*5+(");
            Assert.AreEqual(false, result);
        }
    }
}
