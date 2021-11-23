using System;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Extensions
{
    public static class PhoneExtensions
    {
        private const decimal tax = 0.21m;

        public static decimal PriceWithoutVat(this Phone phone)
        {
            return Math.Round(phone.PriceWithTax / (1 + tax), 2);
        }
    }
}
