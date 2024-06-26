﻿using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.BrandService
{
    public class AddBrandIdToPhoneTests
    {
        private readonly Mock<IRepository<Brand>> _mockBrandRepository;
        private readonly Business.Services.BrandService _brandService;

        public AddBrandIdToPhoneTests()
        {
            _mockBrandRepository = new Mock<IRepository<Brand>>();
            _brandService = new(_mockBrandRepository.Object);
        }

        [Fact]
        public async Task Should_ReturnBrandIdOfOne()
        {
            _mockBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>() { new Brand() { Id = 1, BrandName = "test" } }.AsQueryable());

            long sut = await _brandService.AddBrandIdToPhoneAsync("TEst");

            Assert.Equal(1, sut);
        }

        [Fact]
        public async Task Should_CallBrandRepositoryCreateOnce()
        {
            _mockBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>() { new Brand() { Id = 1, BrandName = "" } }.AsQueryable());

            await _brandService.AddBrandIdToPhoneAsync("TEst");

            _mockBrandRepository.Verify(x => x.CreateAsync(It.IsAny<Brand>()), Times.Once);
        }
    }
}
