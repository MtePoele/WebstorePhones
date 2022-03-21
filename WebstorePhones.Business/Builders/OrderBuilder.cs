using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Business.Builders
{
    public class OrderBuilder
    {
        // TODO Working on this

        // TODO Does this need an interface too? For DI?
        private Order _order = new Order();

        public Order Build()
        {
            return _order;
        }

        public OrderBuilder SetCustomerId(string customerId)
        {
            _order.CustomerId = customerId;
            return this;
        }

        public OrderBuilder SetTotalPrice(decimal totalPrice)
        {
            _order.TotalPrice = totalPrice;
            return this;
        }

        public OrderBuilder SetVatPercentage(double vatPercentage)
        {
            _order.VatPercentage = vatPercentage;
            return this;
        }

        public OrderBuilder SetOrderDate(DateTime dateTime)
        {
            _order.OrderDate = dateTime;
            return this;
        }

        public OrderBuilder SetProductsPerOrderList(List<ProductsPerOrder> productsPerOrders)
        {
            _order.ProductsPerOrderList = productsPerOrders;
            return this;
        }

        public OrderBuilder SetDeleted(bool deleted)
        {
            _order.Deleted = deleted;
            return this;
        }

        public OrderBuilder SetReason(int? reason)
        {
            _order.Reason = reason;
            return this;
        }
    }
}
