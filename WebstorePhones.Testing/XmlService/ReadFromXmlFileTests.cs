using System.Collections.Generic;
using WebstorePhones.Domain.Entities;
using Xunit;

namespace WebstorePhones.Testing.XmlService
{
    public class ReadFromXmlFileTests
    {
        private readonly Business.Services.XmlService _xmlService;

        public ReadFromXmlFileTests()
        {
            _xmlService = new Business.Services.XmlService();
        }

        [Fact]
        public void Should_ReturnListWithFourPhones()
        {
            List<Phone> phones = _xmlService.ReadFromXmlFile("PhoneList001.xml");

            Assert.Equal(4, phones.Count);
        }
    }
}
