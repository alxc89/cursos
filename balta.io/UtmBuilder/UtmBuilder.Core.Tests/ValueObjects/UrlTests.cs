using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string InvalidUrl = "banana";
        private const string ValidUrl = "https://balta.io";
        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            new Url(InvalidUrl);
        }

        [TestMethod]
        public void ShouldNotReturnExceptionWhenUrlIsValid()
        {
            new Url(ValidUrl);
            Assert.IsTrue(true);
        }
    }
}
