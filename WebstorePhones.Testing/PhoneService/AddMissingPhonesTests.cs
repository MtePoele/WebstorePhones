using Moq;
using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class AddMissingPhonesTests
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Mock<ILogger> _logger;
        private readonly Business.Services.PhoneService _phoneService;

        public AddMissingPhonesTests()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _logger = new Mock<ILogger>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object, _logger.Object);
        }

        [Fact]
        public void Should_Return_1()
        {
            Phone phone = new()
            {
                Brand = new Brand()
                {
                    BrandName = "a",
                    Id = 20
                },
                Type = "b",
                Description = "c",
                Stock = 5,
                PriceWithTax = 100
            };

            List<Phone> phoneList = new() { phone };

            int result = _phoneService.AddMissingPhones(phoneList);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Return_0()
        {
            List<Phone> listPhones = new List<Phone>()
            {
                new Phone()
                {
                    Brand = new Brand()
                    {
                        BrandName = "A", Id = 1
                    },
                    Type = "B",
                    Description = "C"
                }
            };

            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(listPhones.AsQueryable());

            int result = _phoneService.AddMissingPhones(listPhones);

            Assert.Equal(0, result);
        }
    }
}
