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

        public void Should_Return_AListWithThreePhones()
        {

            _mockPhoneRepository.Setup(x => x.GetAll()).Returns(
                new List<Phone>()
                {
                    new Phone()
                    {
                        new Brand()
                        {
                            Id = 1,
                            BrandName = "test"
                        }
                    },
                    new Phone()
                    {
                        Type = "test"
                    },
                    new Phone()
                    {
                        Description = "test"
                    }
                });

            List<Phone> phones = _phoneService.Search("test").ToList();

            Assert.Equal(3, phones.Count);
        }
    }
}
