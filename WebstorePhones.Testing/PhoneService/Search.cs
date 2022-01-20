using Moq;
using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class Search
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Business.Services.PhoneService _phoneService;

        public Search()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object);
        }

        [Fact]
        public void Should_Return_OnePhoneWithMatchingBrand()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ BrandName = "test"}, Type = "", Description = ""}
                }.AsQueryable());
            //_mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand() { BrandName = "test"});

            List<Phone> phones = _phoneService.Search("TEst").ToList();

            Assert.Single(phones);
        }

        [Fact]
        public void Should_Return_OnePhoneWithMatchingType()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ BrandName = ""}, Description = "", Type = "test"}
                }.AsQueryable());
            _mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand() { BrandName = "" });

            List<Phone> phones = _phoneService.Search("TEst").ToList();

            Assert.Single(phones);
        }

        [Fact]
        public void Should_Return_OnePhoneWithMatchingDescription()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone(){Brand = new Brand(){ Id = 1, BrandName = ""}, Description = "test", Type = ""}
                }.AsQueryable());
            _mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand() { BrandName = "" });

            List<Phone> phones = _phoneService.Search("TEst").ToList();

            Assert.Single(phones);
        }


    }
}
