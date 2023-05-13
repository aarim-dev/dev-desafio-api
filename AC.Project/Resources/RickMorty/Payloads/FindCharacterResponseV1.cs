using AC.Project.Resources.RickMorty.Entities;

namespace AC.Project.Resources.RickMorty.Payloads
{
    public class FindCharacterResponseV1
    {
        public Info info { get; set; }

        public List<Character> results { get; set; }

        public FindCharacterResponseV1(Info info, List<Character> results)
        {
            this.info = info;
            this.results = results;
        }
    }
}
