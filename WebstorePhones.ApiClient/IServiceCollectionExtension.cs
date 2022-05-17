using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebstorePhones.ApiClient
{
    public static class IServiceCollectionExtension
    {
        private static IServiceCollection AddPhoneShopApiClient(this IServiceCollection iServiceCollection)
        {
            iServiceCollection.AddScoped(typeof(IApiClient<>), typeof(ApiClient<>));
            iServiceCollection.AddHttpClient(nameof(ApiClient), httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:44311/");
            });
            return iServiceCollection;
        }
    }
}
