using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Spectrum.Ird.Tests
{
    [TestClass]
    public class NZBankAccountUnitTests
    {
        [TestMethod]
        public void IsValid_Example1_ReturnsTrue()
        {
            // arrange
            var validator = new NZBankAccount(1, 902, 68389, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example1_ReturnsFormattedAccountNumber()
        {
            // arrange
            var validator = new NZBankAccount(1, 902, 68389, 0);

            // act
            var result = validator.ToString();

            // assert
            Assert.AreEqual("01-0902-0068389-00", result);
        }

        [TestMethod]
        public void IsValid_Example2_ReturnsTrue()
        {
            // arrange
            var validator = new NZBankAccount(8, 6523, 1954512, 1);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example2_ReturnsFormattedAccountNumber()
        {
            // arrange
            var validator = new NZBankAccount(8, 6523, 1954512, 1);

            // act
            var result = validator.ToString();

            // assert
            Assert.AreEqual("08-6523-1954512-01", result);
        }

        [TestMethod]
        public void IsValid_Example3_ReturnsTrue()
        {
            // arrange
            var validator = new NZBankAccount(26, 2600, 320871, 32);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_Example3_ReturnsFormattedAccountNumber()
        {
            // arrange
            var validator = new NZBankAccount(26, 2600, 320871, 32);

            // act
            var result = validator.ToString();

            // assert
            Assert.AreEqual("26-2600-0320871-32", result);
        }

        [TestMethod]
        public void IsValid_BankAccountWithZeroes_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(0, 0, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_BankTooLong_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(999, 0, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_BranchTooLong_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(99999, 0, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_AccountBaseTooLong_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(999_999_999, 0, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_SuffixTooLong_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(0, 0, 0, 99999);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_InvalidBank_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(99, 0, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_InvalidBranch_ReturnsFalse()
        {
            // arrange
            var validator = new NZBankAccount(1, 9999, 0, 0);

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Parse_WellFormedWithSpaces_CreatesInstance()
        {
            // arrange
            var validator = NZBankAccount.Parse("01 0902 0068389 00");

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Parse_WellFormedWithHyphens_CreatesInstance()
        {
            // arrange
            var validator = NZBankAccount.Parse("01-0902-0068389-00");

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Parse_WellFormedWithDots_CreatesInstance()
        {
            // arrange
            var validator = NZBankAccount.Parse("01.0902.0068389.00");

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Parse_WellFormedWithThreeDigitSuffix_CreatesInstance()
        {
            // arrange
            var validator = NZBankAccount.Parse("01-0902-0068389-000");

            // act
            var result = validator.IsValid();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_MalformedAccountNumber_ThrowsInvalidFormatException()
        {
            // act
            NZBankAccount.Parse("xxx");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_Null_ThrowsInvalidFormatException()
        {
            // act
            NZBankAccount.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_Empty_ThrowsInvalidFormatException()
        {
            // act
            NZBankAccount.Parse(string.Empty);
        }

        [TestMethod]
        public void TryParse_WellFormedWithSpaces_ReturnsTrue()
        {
            // arrange/act
            var result = NZBankAccount.TryParse("01 0902 0068389 00", out _);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_WellFormedWithHyphens_ReturnsTrue()
        {
            // arrange/act
            var result = NZBankAccount.TryParse("01-0902-0068389-00", out _);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_WellFormedWithDots_ReturnsTrue()
        {
            // arrange/act
            var result = NZBankAccount.TryParse("01.0902.0068389.00", out _);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_WellFormedWithThreeDigitSuffix_ReturnsTrue()
        {
            // arrange/act
            var result = NZBankAccount.TryParse("01 0902 0068389 000", out _);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_MalformedAccountNumber_ReturnsFalse()
        {
            // arrange/act
            var result = NZBankAccount.TryParse("01 0902 0068389 00", out _);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_Null_ReturnsFalse()
        {
            // arrange/act
            var result = NZBankAccount.TryParse(null, out _);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_Empty_ReturnsFalse()
        {
            // arrange/act
            var result = NZBankAccount.TryParse(string.Empty, out _);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WellFormedAccountNumberInvalid_ReturnsFalse()
        {
            // arrange
            var isParsed = NZBankAccount.TryParse("00-0000-0000000-00", out NZBankAccount validator);

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsTrue(isParsed);
            Assert.IsFalse(isValid);
        }
    }
}