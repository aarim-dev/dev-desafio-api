using System;
using System.ComponentModel;

namespace Aarim.Desafio.RickMorty.Models
{
    //https://rickandmortyapi.com/documentation/#location-schema
    public class Location
    {
        [Description("The id of the location.")]
        public int Id { get; set; }

        [Description("The name of the location.")]
        public string? Name { get; set; }

        [Description("The type of the location.")]
        public string? Type { get; set; }

        [Description("The dimension in which the location is located.")]
        public string? Dimension { get; set; }

        [Description("List of character who have been last seen in the location.")]
        public List<string>? Residents { get; set; }

        [Description("Link to the location's own endpoint.")]
        public string? Url { get; set; }

        [Description("Time at which the location was created in the database.")]
        public string? Created { get; set; }
    }
}

