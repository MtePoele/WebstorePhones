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
    public class Delete
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Business.Services.PhoneService _phoneService;

        public Delete()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object);
        }

        [Fact]
        public void Should_CallPhoneRepositoryDelete_Once()
        {
            _phoneService.Delete(1);

            _mockPhoneRepository.Verify(x => x.Delete(It.IsAny<long>()), Times.Once);
        }
    }
}
