using System;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class TaxService : ITaxService
    {
        private readonly double Tax = 0.21;
        public double CalculateWithoutTax(double priceWithTax)
        {
            return Math.Round(priceWithTax / (1 + Tax), 2);
        }
    }
}
