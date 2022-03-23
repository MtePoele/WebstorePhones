using System;
using System.Collections.Generic;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        private Order _order = new Order();

        public Order Build()
        {
            return _order;
        }

        public IOrderBuilder SetCustomerId(string customerId)
        {
            _order.CustomerId = customerId;
            return this;
        }

        public IOrderBuilder SetTotalPrice(decimal totalPrice)
        {
            _order.TotalPrice = totalPrice;
            return this;
        }

        public IOrderBuilder SetVatPercentage(double vatPercentage)
        {
            _order.VatPercentage = vatPercentage;
            return this;
        }

        public IOrderBuilder SetOrderDate()
        {
            _order.OrderDate = DateTime.Now;
            return this;
        }

        public IOrderBuilder SetProductsPerOrderList(List<ProductsPerOrder> productsPerOrders)
        {
            _order.ProductsPerOrderList = productsPerOrders;
            return this;
        }

        public IOrderBuilder SetDeleted(bool deleted)
        {
            _order.Deleted = deleted;
            return this;
        }

        public IOrderBuilder SetReason(int? reason)
        {
            _order.Reason = reason;
            return this;
        }
    }
}
