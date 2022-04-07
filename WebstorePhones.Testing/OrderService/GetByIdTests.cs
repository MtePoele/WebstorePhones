using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Xunit;

namespace WebstorePhones.Testing.OrderService
{
    public class GetByIdTests
    {
        private readonly Mock<IRepository<Order>> _mockOrderRepository;
        private readonly Business.Services.OrderService _orderService;

        public GetByIdTests()
        {
            _mockOrderRepository = new Mock<IRepository<Order>>();
            _orderService = new(_mockOrderRepository.Object);
        }

        [Fact]
        public void Should_CallOrderRepositoryGetByIdOnce()
        {
            _mockOrderRepository.Setup(x => x.GetById(1)).Returns(new Order());

            _orderService.GetById(string.Empty, 1);

            _mockOrderRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Fact]
        public void Should_ReturnOrderWithCustomerIdUser()
        {
            _mockOrderRepository.Setup(x => x.GetById(1)).Returns(new Order { CustomerId = "user"});

            Order sut = _orderService.GetById("user", 1);

            Assert.Equal("user", sut.CustomerId);
        }

        [Fact]
        public void Should_ReturnNewOrder()
        {
            _mockOrderRepository.Setup(x => x.GetById(1)).Returns(new Order { CustomerId = "not a user" });

            Order sut = _orderService.GetById("user", 1);

            Assert.Equal(new Order().CustomerId, sut.CustomerId);
        }
    }
}
