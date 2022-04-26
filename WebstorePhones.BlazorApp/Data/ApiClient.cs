using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebstorePhones.BlazorApp
{
    public class ApiClient<T> : IApiClient<T> where T : class
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<T>> GetAsync(string url)
        {
            return await _client.GetFromJsonAsync<List<T>>(url);
        }

        public async Task<T> GetAsync(long id)
        {
            return await _client.GetFromJsonAsync<T>($"https://localhost:44311/api/Phones/getbyid?id={id}");
        }

        public async Task PostAsync(T item, string url)
        {
            //TODO Needs authorization
            _client.PostAsJsonAsync<T>(url, item);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO Needs authorization
            await _client.DeleteAsync($"https://localhost:44311/api/Phones/delete?id={id}");
        }
    }
}
