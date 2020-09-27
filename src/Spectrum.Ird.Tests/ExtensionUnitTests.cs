using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Ird.Tests
{
    [TestClass]
    public class ExtensionUnitTests
    {
        [TestMethod]
        public void IsValidIrdNumber_Example1_ReturnsTrue()
        {
            // arrange
            long irdNumber = 49091850;

            // act
            var result = irdNumber.IsValidIrdNumber();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidNZBankAccount_Example1_ReturnsTrue()
        {
            // arrange
            var account = "26-2600-0320871-32";

            // act
            var result = account.IsValidNZBankAccount();

            // assert
            Assert.IsTrue(result);
        }
    }
}
