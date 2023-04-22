using RickAndMortyApi.Wrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickAndMortyApi.Wrapper.Interfaces
{
    public interface IRickAndMortyCharacters
    {
        /// <summary>
        /// Lista os personagens por status e species e quantidade mínima de episódios
        /// </summary>
        /// <param name="status">Valor do filtro do status</param>
        /// <param name="species">Valor do filtro do species</param>
        /// <param name="minimumEpisodes">Quantidade mínima de episódios</param>
        /// <returns>Retorna uma lista do objeto <see cref="RickAndMortyCharacter"/></returns>
        Task<IList<RickAndMortyCharacter>> ListByStatusAndSpeciesAndMinimumEpisodesAsync(string status, string species, int minimumEpisodes);
    }
}
