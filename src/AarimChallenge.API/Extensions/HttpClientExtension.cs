using AarimChallenge.API.Data.Config;

namespace AarimChallenge.API.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddRickAndMortyHttpClient(this IServiceCollection services, IConfiguration config)
        {
            var rickAndMortyApiConfig = new RickAndMortyApiConfig(config);

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(rickAndMortyApiConfig.BaseAddress!)
            };

            services.AddSingleton(httpClient);

            return services;
        }
    }
}
