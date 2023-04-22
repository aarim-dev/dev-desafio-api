using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RickAndMorty.CrossCutting.Settings;
using RickAndMortyApi.Wrapper;
using RickAndMortyApi.Wrapper.Interfaces;
using System;

namespace RickAndMorty.Settings
{
    public static class IoCContainerExtensions
    {
        /// <summary>
        /// Configura a injeção da API pública Rick And Morty
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings">Classe das configurações da aplicação</param>
        /// <returns></returns>
        public static IServiceCollection AddRickAndMortyApi(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient(appSettings.RickAndMortyApiSettings.Id, options =>
            {
                options.BaseAddress = new Uri(appSettings.RickAndMortyApiSettings.BaseUrl);
            });

            return services;
        }

        /// <summary>
        /// Configura a injeção dos serviços
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRickAndMortyCharacters, RickAndMortyCharacters>();

            return services;
        }

        /// <summary>
        /// Configura a documentação do Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rick And Morty",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}
