﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Ird.Tests
{
    [TestClass]
    public class IrdNumberUnitTests
    {
        [TestMethod]
        public void IsValid_Example1_ReturnsTrue()
        {
            // arrange
            var irdNumber = new IrdNumber(49091850);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StaticIsValid_Example1_ReturnsTrue()
        {
            // arrange
            var irdNumber = 49091850;

            // act
            var result = IrdNumber.IsValid(irdNumber);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example1ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(49091850);

            // act
            var result = irdNumber.ToString();

            // assert
            Assert.AreEqual("49-091-850", result);
        }

        [TestMethod]
        public void IsValid_Example2_ReturnsTrue()
        {
            // arrange
            var irdNumber = new IrdNumber(35901981);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example2ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(35901981);

            // act
            var result = irdNumber.ToString();

            // assert
            Assert.AreEqual("35-901-981", result);
        }

        [TestMethod]
        public void IsValid_Example3_ReturnsTrue()
        {
            // arrange
            var irdNumber = new IrdNumber(49098576);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example3ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(49098576);

            // act
            var result = irdNumber.ToString();

            // assert
            Assert.AreEqual("49-098-576", result);
        }

        [TestMethod]
        public void IsValid_Example4_ReturnsTrue()
        {
            // arrange
            var irdNumber = new IrdNumber(136410132);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example4ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(136410132);

            // act
            var result = irdNumber.ToString();

            // assert
            Assert.AreEqual("136-410-132", result);
        }

        [TestMethod]
        public void IsValid_Example5_ReturnsFalse()
        {
            // arrange
            var irdNumber = new IrdNumber(136410133);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_Example5ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(136410133);

            // act
            var result = irdNumber.ToString();

            // assert
            Assert.AreEqual("136-410-133", result);
        }

        [TestMethod]
        public void StaticIsValid_Example5_ReturnsFalse()
        {
            // arrange
            var irdNumber = 136410133;

            // act
            var result = IrdNumber.IsValid(irdNumber);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_Example6_ReturnsFalse()
        {
            // arrange
            var irdNumber = new IrdNumber(9125568);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToString_Example6ReturnsFormattedIrdNumber()
        {
            // arrange
            var irdNumber = new IrdNumber(9125568);

            // act
             irdNumber.ToString();
        }

        [TestMethod]
        public void IsValid_Zero_ReturnsFalse()
        {
            // arrange
            var irdNumber = new IrdNumber(0);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_LessThanLowerLimit_ReturnsFalse()
        {
            // arrange
            var irdNumber = new IrdNumber(9999999);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_GreaterThanUpperLimit_ReturnsFalse()
        {
            // arrange
            var irdNumber = new IrdNumber(150000001);

            // act
            var result = irdNumber.IsValid();

            // assert
            Assert.IsFalse(result);
        }
    }
}
