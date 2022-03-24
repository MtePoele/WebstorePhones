using System.Collections.Generic;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Create an Order.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="userId"></param>
        /// <returns>Order</returns>
        Task<Order> CreateAsync(List<ProductsPerOrder> products, string userId);
        /// <summary>
        /// Get an Order by its supplied ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns>Only returns Order if userId matches the CustomerId of the order.</returns>
        Order GetById(string userId, long id);
        /// <summary>
        /// Get all orders of the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Order</returns>
        List<Order> Get(string userId);
        /// <summary>
        /// Sets the "Deleted" property of the selected Order to true.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string userId, long id);
    }
}
