using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebstorePhones.BlazorApp
{
    public interface IApiClient<T> where T : class
    {
        Task<List<T>> GetAsync(string url);
        Task<T> GetAsync(long id);
        Task<HttpResponseMessage> PostAsync(string url, T item);
        Task DeleteAsync(string url, long id);
    }
}
