using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderService(IRepository<Order> orderRepository, UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public Order GetById(IdentityUser user, long id)
        {
            //todo Return exception or null if false
            Order order = _orderRepository.GetById(id);
            return order.CustomerId == user.Id ? order : new Order();
        }

        public List<Order> Get(IdentityUser user)
        {
            return _orderRepository.GetAll().Where(x => x.CustomerId == user.Id).ToList();
        }

        public async Task DeleteAsync(IdentityUser user, long id)
        {
            Order order = GetById(user, id);
            order.Deleted = true;
            await _orderRepository.SaveChangesAsync();
        }
    }
}
