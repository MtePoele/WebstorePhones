using System.Collections.Generic;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IOrderBuilder
    {
        Order Build();
        IOrderBuilder SetCustomerId(string customerId);
        IOrderBuilder SetTotalPrice(decimal totalPrice);
        IOrderBuilder SetVatPercentage(double vatPercentage);
        IOrderBuilder SetOrderDate();
        IOrderBuilder SetProductsPerOrderList(List<ProductsPerOrder> productsPerOrders);
        IOrderBuilder SetDeleted(bool deleted);
        IOrderBuilder SetReason(int? reason);
    }
}
