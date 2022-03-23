using System.Collections.Generic;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(List<ProductsPerOrder> products, string userId);
        Order GetById(string userId, long id);
        List<Order> Get(string userId);
        Task DeleteAsync(string userId, long id);
    }
}
