using System;
using WebstorePhones.Business.Scrapers;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            BelsimpelScraper scraper = new();

            var a = scraper.Execute("https://www.belsimpel.nl/API/vergelijk/v1.4/WebSearch?resultaattype=hardware_only&format=json_html_decoded");
        }
    }
}
