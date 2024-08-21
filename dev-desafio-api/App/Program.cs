using Domain.enums;
using Service;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RickAndMortyApiService service = new RickAndMortyApiService();

            var characters = service.GetAllCharactersBySpeciesStatusAppearances(Species.alien, Status.unknown, 2).GetAwaiter().GetResult();
            foreach (var character in characters)
            {
                Console.WriteLine($"Name: {character.Name}, Species: {character.Species}, Status: {character.Status}");
            }

        }
    }
}