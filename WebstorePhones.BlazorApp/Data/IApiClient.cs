using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebstorePhones.BlazorApp
{
    public interface IApiClient<T> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(long id);
        void Post(T item);
        Task DeleteAsync(long id);
    }
}
