using AC.Project.Resources.RickMorty.Entities;

namespace AC.Project.Application.Web.Payloads
{
    public class GetCharacterResponseV1 : ResponseDTO
    {
        public List<Character> result { get; }

        public GetCharacterResponseV1(string message, List<Character> result) : base(message)
        {
            this.result = result;
        }

        public GetCharacterResponseV1(string message) : base(message)
        {
            result = new List<Character>();
        }
    }
}
