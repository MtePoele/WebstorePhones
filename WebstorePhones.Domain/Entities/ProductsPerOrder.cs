using System.Diagnostics.CodeAnalysis;

namespace WebstorePhones.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class ProductsPerOrder
    {
        public long Id { get; set; }
        public long PhoneId { get; set; }
        public Phone Phone { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public int Amount { get; set; }
    }
}
