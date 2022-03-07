using Moq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.PhoneService
{
    public class GetByIdTests
    {
        private readonly Mock<IRepository<Phone>> _mockPhoneRepository;
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Mock<ILogger> _mockLogger;
        private readonly Business.Services.PhoneService _phoneService;

        public GetByIdTests()
        {
            _mockPhoneRepository = new Mock<IRepository<Phone>>();
            _mockBrandService = new Mock<IBrandService>();
            _mockLogger = new Mock<ILogger>();
            _phoneService = new Business.Services.PhoneService(_mockPhoneRepository.Object, _mockBrandService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Should_CallPhoneRepositoryGetAllOnce()
        {
            Phone phone = _phoneService.GetById(1);

            _mockPhoneRepository.Setup(x => x.GetById(1)).Returns(
                new Phone()
                {
                    Id = 1
                });

            _mockPhoneRepository.Verify(x => x.GetAll(), Times.Once());
        }
    }
}
