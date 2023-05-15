using DesafioRickAndMorty.Application.Service;
using DesafioRickAndMorty.Application.Service.Interface;
using DesafioRickAndMorty.Application.UseCases;
using DesafioRickAndMorty.Application.UseCases.RickAndMortyCharacters.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioRickAndMorty.IOC
{
    public static class RegisterModule
    {
        public static IServiceCollection AddIOC(this IServiceCollection services)
        {
            services.AddScoped<IRickAndMortyApiService, RickAndMortyApiService>();
            services.AddScoped<IRickAndMortyCharactersUseCase, RickAndMortyCharactersUseCase>();

            return services;
        }
    }
}