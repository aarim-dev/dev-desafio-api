using Aarim.Desafio.RickMorty.Models;

namespace Aarim.Desafio.RickMorty.Web.ViewModel
{

    public class IndexModel
    {
        public List<Character> Characters { get; set; } = new();
        public IndexModel(List<Character> characters) => this.Characters = characters;
        public IndexModel() {}

    }
}
