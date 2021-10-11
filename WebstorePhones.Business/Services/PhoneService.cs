using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        private List<Phone> phones = new()
        {
            new Phone()
            {
                Id = 1,
                Brand = "Huawei",
                Type = "P30",
                Description = "6.47\" FHD + (2340x1080) OLED, Kirin 980 Octa - Core(2x Cortex - A76, 2.6GHz + 2x Cortex - A76 1.92GHz + 4x Cortex - A55 1.8GHz), 8GB RAM, 128GB ROM, 40 + 20 + 8 + TOF / 32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1",
                PriceWithTax = 697,
                Stock = 5
            },
            new Phone()
            {
                Id = 2,
                Brand = "Samsung",
                Type = "Galaxy A52",
                Description = "64 megapixel camera, 4k videokwaliteit, 6.5 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd), Water - en stofbestendig(IP67)",
                PriceWithTax = 399,
                Stock = 13
            },
            new Phone()
            {
                Id = 3,
                Brand = "Apple",
                Type = "IPhone 11",
                Description = "Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13 - chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor",
                PriceWithTax = 619,
                Stock = 27
            },
            new Phone()
            {
                Id = 4,
                Brand = "Google",
                Type = "Pixel 4a",
                Description = "12.2 megapixel camera, 4k videokwaliteit, 5.81 inch OLED scherm, 128 GB opslaggeheugen, 3140 mAh accucapaciteit",
                PriceWithTax = 411,
                Stock = 44
            },
            new Phone()
            {
                Id = 5,
                Brand = "Xiaomi",
                Type = "Redmi Note 10 Pro",
                Description = "108 megapixel camera, 4k videokwaliteit, 6.67 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd). Water - en stofbestendig(IP53)",
                PriceWithTax = 298,
                Stock = 1
            }
        };

        public Phone Get(int id)
        {
            return phones.Single(x => id == x.Id);
        }

        public IEnumerable<Phone> Get()
        {
            return phones.OrderBy(x => x.Brand);
        }

        public IEnumerable<Phone> Search(string query)
        {
            query = query.ToLower();
            return phones.Where(x =>
                x.Brand.ToLower().Contains(query) ||
                x.Type.ToLower().Contains(query) ||
                x.Description.ToLower().Contains(query))
                .OrderBy(x => x.Brand);
        }
    }
}
