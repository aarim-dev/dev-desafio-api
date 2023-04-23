using System.ComponentModel.DataAnnotations;

namespace AarimChallenge.API.Data.Filters
{
    public class CharacterFilter
    {
        [Required]
        public string? Status { get; set; }
        
        [Required]
        public string? Species { get; set; }

        [Required]
        public int EpisodesShownGreaterThan { get; set; }

        public bool IsValid(out string message)
        {
            message = string.Empty;

            if (string.IsNullOrEmpty(Status))
            {
                message = $"{nameof(Status)} can't be null or empty.";
                return false;
            }

            if (string.IsNullOrEmpty(Species))
            {
                message = $"{nameof(Species)} can't be null or empty.";
                return false;
            }

            return true;
        }
    }
}
