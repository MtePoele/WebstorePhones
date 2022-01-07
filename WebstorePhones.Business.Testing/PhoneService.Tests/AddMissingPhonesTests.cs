using Moq;
using System.Collections.Generic;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using Xunit;

namespace WebstorePhones.Business.Testing.PhoneServiceTests
{
    public class AddMissingPhonesTests
    {
        [Fact]
        public void Should_Return_Two()
        {
            Mock<IPhoneService> phoneService = new();
            List<Phone> phones = new(2);
            phoneService.Setup(x => x.AddMissingPhones(It.IsAny<List<Phone>>())).Returns(2);

            int actual = phoneService.Object.AddMissingPhones(phones);

            Assert.Equal(2, actual);
        }



    }
}
