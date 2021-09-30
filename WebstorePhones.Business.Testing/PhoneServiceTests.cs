using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;
using Xunit;

namespace WebstorePhones.Business.Testing
{
    public class PhoneServiceTests
    {
        PhoneService phoneService = new();

        [Fact]
        public void Should_ReturnOnlyHuaweiPhone_WhenIdIsTwo()
        {
            // Arrange
            int id = 1;

            // Act
            Phone phone = phoneService.Get(id);

            // Assert
            Assert.Equal("Huawei", phone.Brand);
        }

        [Fact]
        public void Should_ReturnXiaomi_When_ListDotCountIsFive()
        {
            // Arrange & Act
            List<Phone> list = phoneService.Get().ToList();

            // Assert
            Assert.Equal("Xiaomi", list[list.Count - 1].Brand);
        }

        [Fact]
        public void Should_ReturnListOfOneItem_WhenSearchingForApple()
        {
            // Arrange & Act
            List<Phone> tempList = phoneService.Search("Apple").ToList();

            // Assert
            Assert.Single(tempList);
        }
    }
}
