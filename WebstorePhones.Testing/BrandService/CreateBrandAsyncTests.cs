using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.BrandService
{
    public class CreateBrandAsyncTests
    {
        private readonly Mock<IRepository<Brand>> _mockBrandRepository;
        private readonly Business.Services.BrandService _brandService;

        public CreateBrandAsyncTests()
        {
            _mockBrandRepository = new Mock<IRepository<Brand>>();
            _brandService = new(_mockBrandRepository.Object);
        }

        [Fact]
        public async void Should_ReturnStringWasAdded()
        {
            Brand brand = new();

            string sut = await _brandService.CreateBrandAsync(brand);

            Assert.Equal("Brand was added.", sut);
        }

        [Fact]
        public async void Should_CallRepositoryCreateAsyncOnce()
        {
            Brand brand = new();

            string sut = await _brandService.CreateBrandAsync(brand);

            _mockBrandRepository.Verify(x => x.CreateAsync(It.IsAny<Brand>()), Times.Once());
        }

        [Fact]
        public async void Should_CallRepositoryGetAllOnce()
        {
            Brand brand = new();

            await _brandService.CreateBrandAsync(brand);

            _mockBrandRepository.Verify(x => x.CreateAsync(brand));
        }
    }
}
