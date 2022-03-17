using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebstorePhones.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        [Required]
        public double VatPercentage { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public bool Deleted { get; set; } = false;
        public int? Reason { get; set; }
    }
}
