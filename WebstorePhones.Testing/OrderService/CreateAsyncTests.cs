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
    public class CreateAsyncTests
    {
        private readonly Mock<IRepository<Order>> _mockOrderRepository;
        private readonly Business.Services.OrderService _orderService;

        public CreateAsyncTests()
        {
            _mockOrderRepository = new Mock<IRepository<Order>>();
            _orderService = new(_mockOrderRepository.Object);
        }

        [Fact]
        public async void Should_CallOrderRepositoryCreateAsyncOnce()
        {
            List<ProductsPerOrder> list = new();
            string customerId = string.Empty;

            await _orderService.CreateAsync(list, customerId);

            _mockOrderRepository.Verify(x => x.CreateAsync(It.IsAny<Order>()), Times.Once);
        }
    }
}
