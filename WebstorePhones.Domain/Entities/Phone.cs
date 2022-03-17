using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Phone : IEntity
    {
        public long Id { get; set; }
        public Brand Brand { get; set; }
        public long BrandId { get; set; }
        public string Type { get; set; }
        public string FullName { get { return $"{Brand.BrandName} - {Type}"; } }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceWithTax { get; set; }
        public decimal PriceWithoutTax { get { return Math.Round(PriceWithTax / (1 + 0.21m), 2); } }
        public int Stock { get; set; }
    }
}