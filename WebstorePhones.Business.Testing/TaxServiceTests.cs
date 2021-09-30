using WebstorePhones.Business.Services;
using Xunit;

namespace WebstorePhones.Business.Testing
{
    public class TaxServiceTests
    {
        [Fact]
        public void Should_BeTrue_When_ArgumentIsTwoDotFortyTwo()
        {
            // Arrange & Act
            TaxService taxService = new();
            double number = taxService.CalculateWithoutTax(2.42);

            // Assert
            Assert.Equal(2, number);
        }
    }
}
