using System;
using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Domain.Objects;
using WebstorePhones.Business.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class ProductService : IProductService 
    {
        private readonly static List<Phone> phones = new()
        {
            new Phone()
            {
                Brand = "Huawei",
                Type = "P30",
                Description = "6.47\" FHD + (2340x1080) OLED, Kirin 980 Octa - Core(2x Cortex - A76, 2.6GHz + 2x Cortex - A76 1.92GHz + 4x Cortex - A55 1.8GHz), 8GB RAM, 128GB ROM, 40 + 20 + 8 + TOF / 32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1",
                PriceAfterTax = 697,
                Stock = 5
            },
            new Phone()
            {
                Brand = "Samsung",
                Type = "Galaxy A52",
                Description = "64 megapixel camera, 4k videokwaliteit, 6.5 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd), Water - en stofbestendig(IP67)",
                PriceAfterTax = 399,
                Stock = 13
            },
            new Phone()
            {
                Brand = "Apple",
                Type = "IPhone 11",
                Description = "Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13 - chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor",
                PriceAfterTax = 619,
                Stock = 27
            },
            new Phone()
            {
                Brand = "Google",
                Type = "Pixel 4a",
                Description = "12.2 megapixel camera, 4k videokwaliteit, 5.81 inch OLED scherm, 128 GB opslaggeheugen, 3140 mAh accucapaciteit",
                PriceAfterTax = 411,
                Stock = 44
            },
            new Phone()
            {
                Brand = "Xiaomi",
                Type = "Redmi Note 10 Pro",
                Description = "108 megapixel camera, 4k videokwaliteit, 6.67 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd). Water - en stofbestendig(IP53)",
                PriceAfterTax = 298,
                Stock = 1
            }
        };
        private readonly static double Tax = 0.21;

        private static double CalculateBeforeTax(double priceAfterTax)
        {
            return Math.Round(priceAfterTax / (1 + Tax), 2);
        }

        private static List<Phone> SortList(List<Phone> phones)
        {
            phones.Sort((x, y) => string.Compare(x.Brand, y.Brand));
            int phoneId = 0;
            foreach (var phone in phones)
            {
                phone.Id = phoneId;
                phoneId++;
            }
            return phones;
        }

        public static List<Phone> GetAllPhones()
        {

            foreach (var phone in phones)
            {
                phone.PriceBeforeTax = CalculateBeforeTax(phone.PriceAfterTax);
            }
            SortList(phones);

            return phones;
        }

        public static Phone GetPhone(int id)
        {
            return phones.Find(x => id == x.Id);
        }

        private double CalculatePriceBeforeTax(double price)
        {
            price /= 1.21;
            return price;
        }
    }
}
