using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class SearchTests
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Mock<ILogger> _mockLogger;
        private readonly Business.Services.PhoneService _phoneService;

        public SearchTests()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _mockLogger = new Mock<ILogger>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Should_Return_OnePhoneWithMatchingBrand()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ BrandName = "test"}, Type = "", Description = ""}
                }.AsQueryable());

            List<Phone> phones = (await _phoneService.SearchAsync("TEst")).ToList();

            Assert.Single(phones);
        }

        [Fact]
        public async Task Should_Return_OnePhoneWithMatchingType()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ BrandName = ""}, Description = "", Type = "test"}
                }.AsQueryable());
            _mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand() { BrandName = "" });

            List<Phone> phones = (await _phoneService.SearchAsync("TEst")).ToList();

            Assert.Single(phones);
        }

        [Fact]
        public async Task Should_Return_OnePhoneWithMatchingDescription()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ Id = 1, BrandName = ""}, Description = "test", Type = ""}
                }.AsQueryable());
            _mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand() { BrandName = "" });

            List<Phone> phones = (await _phoneService.SearchAsync("TEst")).ToList();

            Assert.Single(phones);
        }


    }
}
