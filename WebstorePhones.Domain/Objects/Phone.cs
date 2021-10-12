using System;

namespace WebstorePhones.Domain.Objects
{
    public class Phone
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string FullName { get { return $"{Brand} - {Type}"; } }
        public string Description { get; set; }
        public decimal PriceWithTax { get; set; }
        public decimal PriceWithoutTax { get { return Math.Round(PriceWithTax / (1 + 0.21m), 2); } }
        public int Stock { get; set; }
    }
}