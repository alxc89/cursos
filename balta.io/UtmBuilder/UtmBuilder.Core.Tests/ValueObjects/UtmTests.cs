using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects
{

    [TestClass]
    public class UtmTests
    {
        private const string Result = "https://balta.io/?" +
            "utm_source=src&utm_medium=med&utm_campaign=name&utm_id=id&utm_term=term&utm_content=cont";
        private readonly Url _url = new("https://balta.io/");
        private readonly Campaign _campaing = new("src", "med", "name", "id", "term", "cont");

        [TestMethod]
        public void ShouldReturnUrlUtm()
        {
            var utm = new Utm(_url, _campaing);

            Assert.AreEqual(Result, utm.ToString());
            Assert.AreEqual(Result, (string)utm);
        }

        [TestMethod]
        public void ShouldReturnUtmUrl()
        {
            Utm utm = Result;
            Assert.AreEqual("https://balta.io/", utm.Url.Address);
            Assert.AreEqual("src", utm.Campaign.Source);
            Assert.AreEqual("med", utm.Campaign.Medium);
            Assert.AreEqual("name", utm.Campaign.Name);
            Assert.AreEqual("id", utm.Campaign.Id);
            Assert.AreEqual("term", utm.Campaign.Term);
            Assert.AreEqual("cont", utm.Campaign.Content);

        }
    }
}
