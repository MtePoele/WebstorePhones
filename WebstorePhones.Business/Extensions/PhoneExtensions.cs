using System;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Extensions
{
    public static class PhoneExtensions
    {
        private const decimal tax = 0.21m;

        /// <summary>
        /// Returns the "price without VAT" as decimal, rounded to 2 decimals.
        /// VAT % is stored in a private const in the extension method.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static decimal PriceWithoutVat(this Phone phone)
        {
            return Math.Round(phone.PriceWithTax / (1 + tax), 2);
        }
    }
}
