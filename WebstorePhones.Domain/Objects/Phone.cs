using System;

namespace WebstorePhones.Domain.Objects
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double PriceWithTax { get; set; }
        public double PriceWithoutTax { get { return Math.Round(PriceWithTax / (1 + 0.21), 2); } }
        public int Stock { get; set; }
    }
}