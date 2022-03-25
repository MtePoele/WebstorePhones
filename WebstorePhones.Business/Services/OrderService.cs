using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Business.Builders;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private const int vatPercentage = 19;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateAsync(List<ProductsPerOrder> products, string customerId)
        {
            OrderBuilder orderBuilder = new();

            Order order = orderBuilder
                .SetCustomerId(customerId)
                .SetVatPercentage(vatPercentage)
                .SetOrderDate()
                .SetProductsPerOrderList(products)
                .SetDeleted(false)
                .Build();

            await _orderRepository.CreateAsync(order);

            return order;
        }

        public Order GetById(string userId, long id)
        {
            Order order = _orderRepository.GetById(id);
            return order.CustomerId == userId ? order : new Order();
        }

        public List<Order> Get(string userId)
        {
            return _orderRepository.GetAll().Where(x => x.CustomerId == userId && x.Deleted == false).ToList();
        }

        public async Task DeleteAsync(string userId, long id)
        {
            Order order = GetById(userId, id);
            order.Deleted = true;
            await _orderRepository.SaveChangesAsync();
        }
    }
}
