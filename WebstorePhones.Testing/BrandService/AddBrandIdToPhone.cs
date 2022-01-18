using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Testing.BrandService
{
    public class AddBrandIdToPhone
    {
        private readonly Mock<IRepository<Brand>> _mockBrandRepository;
        private readonly Business.Services.BrandService _brandService;

        public AddBrandIdToPhone()
        {
            _mockBrandRepository = new Mock<IRepository<Brand>>();
            _brandService = new(_mockBrandRepository.Object);
        }

        [Fact]
        public void Should_ReturnBrandIdOfOne()
        {
            _mockBrandRepository.Setup(x => x.GetAll()).Returns( new List<Brand>() { new Brand() { Id = 1, BrandName = "test"} });

            long sut = _brandService.AddBrandIdToPhone("TEst");

            Assert.Equal(1, sut);
        }

        [Fact]
        public void Should_CallBrandRepositoryCreateOnce()
        {
            _mockBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>() { new Brand() { Id = 1, BrandName = ""} });

            _brandService.AddBrandIdToPhone("TEst");

            _mockBrandRepository.Verify(x => x.Create(It.IsAny<Brand>()), Times.Once);
        }
    }
}
