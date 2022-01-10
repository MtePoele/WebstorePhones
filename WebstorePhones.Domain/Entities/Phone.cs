using System;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    public class Phone : IEntity
    {
        public Phone()
        {

        }

        public Phone(Phone phone)
        {
            Id = phone.Id;
            BrandId = phone.BrandId;
            Type = phone.Type;
            Description = phone.Description;
            PriceWithTax = phone.PriceWithTax;
            Stock = phone.Stock;
        }
        public long Id { get; set; }
        public Brand Brand { get; set; }
        public long BrandId { get; set; }
        public string Type { get; set; }
        public string FullName { get { return $"{Brand} - {Type}"; } }
        public string Description { get; set; }
        public decimal PriceWithTax { get; set; }
        public decimal PriceWithoutTax { get { return Math.Round(PriceWithTax / (1 + 0.21m), 2); } }
        public int Stock { get; set; }
    }
}