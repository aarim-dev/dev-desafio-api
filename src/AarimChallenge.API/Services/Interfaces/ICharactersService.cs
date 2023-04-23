using AarimChallenge.API.Data.Filters;

namespace AarimChallenge.API.Services.Interfaces
{
    public interface ICharactersService
    {
        Task<IEnumerable<string?>> GetNamesShownInMoreThanOneOrMoreEpisodesByStatusAndSpeciesAsync(CharacterFilter filters);
    }
}