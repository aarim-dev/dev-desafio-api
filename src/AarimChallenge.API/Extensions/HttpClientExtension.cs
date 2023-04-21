namespace AarimChallenge.API.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddRickAndMortyHttpClient(this IServiceCollection services, string baseAddress)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };

            services.AddSingleton(httpClient);

            return services;
        }
    }
}
