using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
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

        public async Task<List<Phone>> Get()
        {
            return await _client.GetFromJsonAsync<List<Phone>>("https://localhost:44311/api/Phones");
        }

        public async Task<Phone> Get(long id)
        {
            return await _client.GetFromJsonAsync<Phone>($"https://localhost:44311/api/Phones/{id}");
        }

        public void Post(Phone phone)
        {
            //TODO Needs authorization
            _client.PostAsJsonAsync<Phone>("https://localhost:44311/api/Phones", phone);
        }

        public async Task Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
