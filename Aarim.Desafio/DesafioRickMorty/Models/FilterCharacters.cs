using System;
using Aarim.Desafio.RickMorty.Helpers;

namespace Aarim.Desafio.RickMorty.Models
{

    #region Enum for status e gender
    public enum EStatus
    {
        Unknown,
        Alive,
        Dead
    }

    public enum EGender
    {
        Unknown,
        Female,
        Male,
        Genderless
    }
    #endregion

    //https://rickandmortyapi.com/documentation/#filter-characters
    public class FilterCharacters
    {

        public FilterCharacters(List<int> Ids) => this.Id = Ids;
        public FilterCharacters(int page) => this.Page = page;
        public FilterCharacters() { }

        #region Single parm construction
        private List<int>? Id { get; set; }
        private int? Page { get; set; }
        #endregion

        #region structured construction
        public string? Name { get; set; }
        public EStatus? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public EGender? Gender { get; set; }
        #endregion

        #region Convert to query string params
        public string ToQueryString()
        {
            List<string> values = new();
            if (Id is not null && Id.Any())
            {
                values.Add($"[{string.Join(",", Id)}]");
            }
            else if (Page is not null)
            {
                values.Add($"?page={Page}");
            }
            else
            {
                if (Name.HasValue())
                    values.Add($"name={Name}");

                if (Status.HasValue)
                    values.Add($"status={Enum.GetName<EStatus>(Status.Value)}");

                if (Species.HasValue())
                    values.Add($"species={Species}");

                if (Type.HasValue())
                    values.Add($"type={Type}");

                if (Gender.HasValue)
                    values.Add($"gender={Enum.GetName<EGender>(Gender.Value)}");
            }

            return (values.Count > 1)
                ? $"?{string.Join("&", values)}"
                : values.FirstOrDefault(string.Empty);
        }
        #endregion

    }
}

