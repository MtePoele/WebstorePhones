using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class Get
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Business.Services.PhoneService _phoneService;

        public Get()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object);
        }

        [Fact]
        public void Should_CallPhoneRepositoryGetAllOnce()
        {
            _phoneService.Get();

            _mockPhoneRepository.Verify(x => x.GetAll(), Times.Once());
        }

        [Fact]
        public void Should_CallBrandRepositoryTwice()
        {
            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>() { new Phone(), new Phone() });
            _mockBrandService.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Brand());

            _phoneService.Get();

            _mockBrandService.Verify(x => x.GetById(It.IsAny<long>()), Times.Exactly(2));
        }
    }
}
