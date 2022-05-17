using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace WebstorePhones.ApiClient
{
    public class ApiClient<T> : IApiClient<T> where T : class
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public ApiClient(IHttpClientFactory clientFactory, ILocalStorageService localStorage)
        {
            _client = clientFactory.CreateClient(nameof(ApiClient));
            _localStorage = localStorage;
        }

        public async Task<List<T>> GetAsync(string url)
        {
            await AttachHeader();
            return await _client.GetFromJsonAsync<List<T>>(url);
        }

        public async Task<T> GetAsync(long id)
        {
            await AttachHeader();
            return await _client.GetFromJsonAsync<T>($"https://localhost:44311/api/Phones/getbyid?id={id}");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, T item)
        {
            await AttachHeader();
            return await _client.PostAsJsonAsync<T>(url, item);
        }

        public async Task DeleteAsync(string url, long id)
        {
            await AttachHeader();
            await _client.DeleteAsync(url);
        }

        private async Task AttachHeader()
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("tokenstring"));
        }
    }
}
