using dev_desafio_api.Models;

namespace dev_desafio_api.Dtos.ExternalServices
{
    public class CharactersResponse
    {
        Information Info { get; set; } = null!;

        List<Character> Result = null!;
    }
}