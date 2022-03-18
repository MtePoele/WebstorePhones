using System.ComponentModel.DataAnnotations;

namespace WebstorePhones.Domain.Entities
{
    public class ProductsPerOrder
    {
        public long Id { get; set; }
        [Required]
        public Phone Phone { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
