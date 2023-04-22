using System.Collections.Generic;

namespace RickAndMortyApi.Wrapper.Models
{
    public class RickAndMortyResponse<TResult>
        where TResult : class
    {
        public RickAndMortyInfo Info { get; set; }
        public IList<TResult> Results { get; set; }
    }
}
