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
    public class GetTests
    {
        private readonly Mock<IRepository<Order>> _mockOrderRepository;
        private readonly Business.Services.OrderService _orderService;

        public GetTests()
        {
            _mockOrderRepository = new Mock<IRepository<Order>>();
            _orderService = new(_mockOrderRepository.Object);
        }

        [Fact]
        public void Should_CallOrderRepositoryGetAllOnce()
        {
            _mockOrderRepository.Setup(x => x.GetAll()).Returns(new List<Order>
                {
                    new Order{ CustomerId = string.Empty },
                    new Order{ CustomerId = string.Empty }
                }.AsQueryable());

            _orderService.Get(string.Empty);


            _mockOrderRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
