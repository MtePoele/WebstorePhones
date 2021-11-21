using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Extensions
{
    public static class PhoneExtensions
    {
        public static decimal ttt(this Phone PriceWithoutVat, decimal PriceWithVat)
        {
            return Math.Round(PriceWithVat / (1 + 21), 2);
        }
    }
}
