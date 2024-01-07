using dev_desafio_api.Models;

namespace dev_desafio_api.Dtos.ExternalServices
{
    public class CharactersResponse
    {
        public Information Info { get; set; } = null!;

        public List<Character> Result = null!;
    }
}