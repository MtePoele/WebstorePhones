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

        //[Fact]
        //private void Should_Return_AListWithTwoPhones()
        //{
        //    _mockPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>() 
        //    { 
        //        new Phone()
        //        {
        //            Brand = new Brand()
        //            {
        //                BrandName = "a"
        //            }
        //        }, 
        //        new Phone()
        //        {
        //            Brand = new Brand()
        //            {
        //                BrandName = "b"
        //            } 
        //        }
        //    });

        //    List<Phone> phones = new();
        //    phones = _phoneService.Get().ToList();

        //    Assert.Equal(2, phones.Count);
        //}
    }
}
