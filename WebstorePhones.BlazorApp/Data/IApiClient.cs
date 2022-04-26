using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebstorePhones.BlazorApp
{
    public interface IApiClient<T> where T : class
    {
        Task<List<T>> GetAsync(string url);
        Task<T> GetAsync(long id);
        async Task PostAsync(T item, string url);
        Task DeleteAsync(long id);
    }
}
