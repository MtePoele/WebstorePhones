using Moq;
using System;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.BrandService
{
    public class GetById
    {
        private readonly Mock<IRepository<Brand>> _mockBrandRepository;
        private readonly Business.Services.BrandService _brandService;

        public GetById()
        {
            _mockBrandRepository = new Mock<IRepository<Brand>>();
            _brandService = new(_mockBrandRepository.Object);
        }

        [Fact]
        public void Should_Return_ABrandWithAnIdOf1()
        {
            _mockBrandRepository.Setup(x => x.GetById(1)).Returns(
                new Brand()
                {
                    BrandName = "a",
                    Id = 1
                });

            Brand brand = _brandService.GetById(1);

            Assert.Equal("1", brand.Id.ToString());
        }

        [Fact]
        public void Should_CallBrandDepositoryGetByIdOnce()
        {
            _brandService.GetById(1);

            _mockBrandRepository.Verify(x => x.GetById(1), Times.Once);
        }
    }
}
