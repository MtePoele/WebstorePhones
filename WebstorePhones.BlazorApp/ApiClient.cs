using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.BlazorApp
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }


        private void Iets()
        {
            using (HttpClient client = new())
            {
                var a = client.GetFromJsonAsync<Brand>("https://localhost:44311/api/Brand/getbyid");
                
            }
        }
    }
}
