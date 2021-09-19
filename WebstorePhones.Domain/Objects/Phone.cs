namespace WebstorePhones.Domain.Objects
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double PriceAfterTax { get; set; }
        public double PriceBeforeTax { get; set; }
    }
}
