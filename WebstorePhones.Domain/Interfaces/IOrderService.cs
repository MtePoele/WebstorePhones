using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
        Order GetById(IdentityUser user, long id);
        List<Order> Get(IdentityUser user);
        Task DeleteAsync(IdentityUser user, long id);
    }
}
