using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Ird.Tests
{
    public sealed class ExpectedExceptionWithMessage : ExpectedExceptionBaseAttribute
    {
        private Type _type;
        private string _message;

        public ExpectedExceptionWithMessage(Type expectedExceptionType, string expectedExceptionMessage)
        {
            _type = expectedExceptionType;
            _message = expectedExceptionMessage;
        }

        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);

            Assert.IsInstanceOfType(exception, _type, $"Test method threw exception {exception.GetType()}, but exception {_type} was expected.");

            Assert.AreEqual(_message, exception.Message, $"Test method threw exception with message \"{exception.Message}\", but message \"{_message}\" was expected.");
        }
    }
}
