using Domain.Models.Dto;
using Domain.Models.Entities;
using System.Text.Json;

namespace Service;
public class RickAndMortyApiService
{
    private static readonly HttpClient client = new HttpClient();

    /// <summary>
    /// filtra os personagens de acordo com os requisitos do desafio técnico
    /// </summary>
    /// <param name="species">espécie do personagem</param>
    /// <param name="status">status do personagem</param>
    /// <param name="epAppearances">número de episódios que o personagem apareceu</param>
    /// <returns>uma lista com todos os personagens de acordo com o filtro de espécie, status e número de aparições</returns>
    public async Task<List<Character>> GetAllCharactersBySpeciesStatusAppearances(Enum species, Enum status, int epAppearances)
    {
        var url = $"https://rickandmortyapi.com/api/character/?species={species}&status={status}";
        var allCharacters = new List<Character>();

        await FetchRecursively(url, allCharacters);
        return allCharacters.Where(c => c.Episode.Count >= epAppearances).ToList();
    }

    /// <summary>
    /// Consome a Api recursivamente para retornar todos os personagens
    /// </summary>
    /// <param name="url">endpoint da Api</param>
    /// <param name="allCharacters">Lista que será preenchida com todos os personagens</param>
    /// <returns></returns>
    private async Task FetchRecursively(string url, List<Character> allCharacters)
    {
        var response = await client.GetStringAsync(url);

        if (!string.IsNullOrEmpty(response))
        {
            var characterResponse = JsonSerializer.Deserialize<ResponseDto>(response);

            if (characterResponse != null)
            {
                if (characterResponse.Results != null)
                {
                    allCharacters.AddRange(characterResponse.Results);
                }

                if (!string.IsNullOrEmpty(characterResponse.Info?.Next))
                {
                    await FetchRecursively(characterResponse.Info.Next, allCharacters);
                }
            }
        }
    }
}