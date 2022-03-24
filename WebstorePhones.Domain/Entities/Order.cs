using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Order : IEntity
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
        public List<ProductsPerOrder> ProductsPerOrderList { get; set; }
        public bool Deleted { get; set; } = false;
        public int? Reason { get; set; }
    }
}
