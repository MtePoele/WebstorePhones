using Moq;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using Xunit;

namespace WebstorePhones.Business.Testing.PhoneServiceTests
{
    public class GetByIdTests
    {
        Mock<IPhoneService> sut = new();

        [Fact]
        public void Should_Return_OnePhone()
        {

            sut.Setup(x => x.Get(1)).Returns(new Phone() { Type = "Pear" });

            Phone phone = sut.Object.Get(1);

            Assert.Equal("Pear", phone.Type);
        }

        [Fact]
        public void Should_Call_GetById_Once()
        {
            sut.Setup(x => x.Get(It.IsAny<int>())).Returns(new Phone());

            //var phone = sut.Object.Get("");

            sut.Verify(x => x.Get(1), Times.Once);
        }
    }
}
