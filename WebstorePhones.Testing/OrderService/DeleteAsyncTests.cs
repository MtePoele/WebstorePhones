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
    public class DeleteAsyncTests
    {
        private readonly Mock<IRepository<Order>> _mockOrderRepository;
        private readonly Business.Services.OrderService _orderService;

        public DeleteAsyncTests()
        {
            _mockOrderRepository = new Mock<IRepository<Order>>();
            _orderService = new(_mockOrderRepository.Object);
        }

        [Fact]
        public async void Should_CallGetByIdOnceWithIdOne()
        {
            _mockOrderRepository.Setup(x => x.GetById(1)).Returns(new Order() { Id = 1, Deleted = false });

            await _orderService.DeleteAsync(string.Empty, 1);

            _mockOrderRepository.Verify(x => x.GetById(1), Times.Once);
        }
    }
}
