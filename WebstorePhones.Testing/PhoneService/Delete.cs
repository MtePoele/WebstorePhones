﻿using Moq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class Delete
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Mock<ILogger> _mockLogger;
        private readonly Business.Services.PhoneService _phoneService;

        public Delete()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _mockLogger = new Mock<ILogger>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Should_CallPhoneRepositoryDelete_Once()
        {
            _phoneService.Delete(1);

            _mockPhoneRepository.Verify(x => x.Delete(1), Times.Once);
        }
    }
}
