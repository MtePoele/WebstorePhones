using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderService(IRepository<Order> orderRepository, UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public async Task CreateOrder(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public Order GetById(long id)
        {
            return _orderRepository.GetById(id);
        }

        [Authorize]
        public List<Order> Get(string userId)
        {
            // TODO add identity.userId or something
            return _orderRepository.GetAll().Where(x => x.CustomerId == "").ToList();
        }

        public void DeleteOrder(long id)
        {
            // TODO Needs savechanges
            Order order = GetById(id);
            order.Deleted = true;
        }
    }
}
