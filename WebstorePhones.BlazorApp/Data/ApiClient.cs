using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace WebstorePhones.BlazorApp
{
    public class ApiClient<T> : IApiClient<T> where T : class
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public ApiClient(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<List<T>> GetAsync(string url)
        {
            return await _client.GetFromJsonAsync<List<T>>(url);
        }

        public async Task<T> GetAsync(long id)
        {
            return await _client.GetFromJsonAsync<T>($"https://localhost:44311/api/Phones/getbyid?id={id}");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, T item)
        {
            //TODO Needs authorization
            _client.DefaultRequestHeaders.Add("Authorization", "bearer " + _localStorage.GetItemAsync<string>("tokenstring"));
            return await _client.PostAsJsonAsync<T>(url, item);
        }

        public async Task DeleteAsync(string url, long id)
        {
            url = url + id;
            //TODO Needs authorization
            await _client.DeleteAsync(url);
        }
    }
}
