using System;

namespace Aarim.Desafio.RickMorty.Models
{
    //https://rickandmortyapi.com/documentation/#rest
    public class RickAndMortyApiResponse
	{
		public ResponseInfo Info { get; set; } = new();
        public List<Character> Results { get; set; } = new();
    }
}

