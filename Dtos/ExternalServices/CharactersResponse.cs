namespace dev_desafio_api.Dtos.ExternalServices
{
    public class CharactersResponse
    {
        public InformationResponse Info { get; set; } = null!;

        public List<CharacterRespose> Results = null!;
    }
}