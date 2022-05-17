using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Scrapers
{
    public class BelsimpelScraper //: IScraper
    {
        public bool CanExecute(string url)
        {
            throw new NotImplementedException();
            //return url.Contains("belsimpel.nl/telefoon");
        }

        //public async Task<List<Phone>> Execute(string url)
        //{
        //    throw new NotImplementedException();
        //    //using var htmlReader = new StreamReader(client.OpenRead("https://belsimpel.nl/telefoon"));
        //    //var token = ExtractToken(await htmlReader.ReadToEndAsync());

        //    //HttpClient client = new HttpClient();
        //    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
        //    //client.DefaultRequestHeaders.Accept.Clear();
        //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    //var response = client.GetStringAsync(url);
        //    //return await response;

        //    //var response = await client.GetStringAsync(url);

        //    //Console.WriteLine(response);

        //    //Console.ReadLine();

        //    //List<Phone> phones = new();

        //    //return phones;
        //}
    }
}
