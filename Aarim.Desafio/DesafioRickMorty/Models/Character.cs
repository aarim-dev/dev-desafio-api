using System;
using System.ComponentModel;

namespace Aarim.Desafio.RickMorty.Models
{
    //https://rickandmortyapi.com/documentation/#character-schema
    public class Character
    {

        [Description("The id of the character.")]
        public int Id { get; set; }

        [Description("The name of the character.")]
        public string? Name { get; set; }

        [Description("The status of the character('Alive', 'Dead' or 'unknown') :: EStatus enum")]
        public string? Status { get; set; }
        
        [Description("The species of the character.")]
        public string? Species { get; set; }

        [Description("The type or subspecies of the character.")]
        public string? Type { get; set; }

        [Description("The gender of the character('Female', 'Male', 'Genderless' or 'unknown') :: EGender enum")]
        public string? Gender { get; set; }

        [Description("Name and link to the character's origin location")]
        public Location? Origin { get; set; }

        [Description("Name and link to the character's last known location endpoint.")]
        public Location? Location { get; set; }

        [Description("Link to the character's image. All images are 300x300px and most are medium shots or portraits since they are intended to be used as avatars.")]
        public string? Image { get; set; }

        [Description("List of episodes in which this character appeared.")]
        public List<string>? Episode { get; set; }

        [Description("Time at which the character was created in the database.")]
        public string? Created { get; set; }

	}
}

