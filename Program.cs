using System;
using System.Collections.Generic;

namespace FivePhonesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static List<Phone> MakeList()
        {
            List<Phone> phones = new()
            {
                new Phone()
                {
                    Brand = "Huawei",
                    Type = "P30",
                    Description = "6.47\" FHD + (2340x1080) OLED, Kirin 980 Octa - Core(2x Cortex - A76, 2.6GHz + 2x Cortex - A76 1.92GHz + 4x Cortex - A55 1.8GHz), 8GB RAM, 128GB ROM, 40 + 20 + 8 + TOF / 32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1",
                    Price = 697
                },
                new Phone()
                {
                    Brand = "Samsung",
                    Type = "Galaxy A52",
                    Description = "64 megapixel camera, 4k videokwaliteit, 6.5 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd), Water - en stofbestendig(IP67)",
                    Price = 399
                },
                new Phone()
                {
                    Brand = "Apple",
                    Type = "IPhone 11",
                    Description = "Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13 - chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor",
                    Price = 619
                },
                new Phone()
                {
                    Brand = "Google",
                    Type = "Pixel 4a",
                    Description = "12.2 megapixel camera, 4k videokwaliteit, 5.81 inch OLED scherm, 128 GB opslaggeheugen, 3140 mAh accucapaciteit",
                    Price = 411
                },
                new Phone()
                {
                    Brand = "Xiaomi",
                    Type = "Redmi Note 10 Pro",
                    Description = "108 megapixel camera, 4k videokwaliteit, 6.67 inch AMOLED scherm, 128 GB opslaggeheugen(Uitbreidbaar met Micro - sd). Water - en stofbestendig(IP53)",
                    Price = 298
                },
            };

            return phones;
        }

        private static void MainMenu()
        {
            List<Phone> phonesList = MakeList();

            Console.WriteLine(
                "Kies een telefoonmerk:\n" +
                "0. Huawei\n" +
                "1. Samsung\n" +
                "2. Apple\n" +
                "3. Google\n" +
                "4. Xiaomi");
            Console.WriteLine();

            Console.Write("Uw keuze: ");

            int userChoice = int.Parse(Console.ReadKey().KeyChar.ToString());

            Console.Clear();

            Console.WriteLine($"{phonesList[userChoice].Brand} {phonesList[userChoice].Type}, Price: {phonesList[userChoice].Price}");
            Console.WriteLine(phonesList[userChoice].Description);
            Console.WriteLine();
            Console.WriteLine("Druk op een willekeurige toets om terug te gaan naar het hoofdmenu.");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
    }
}
