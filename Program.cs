using dev_desafio_api.DataAccess.MongoDb;
using dev_desafio_api.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

RickAndMortyDao _rickAndMortyDao = new();
builder.Services.
AddSingleton(_rickAndMortyDao).
AddSingleton<RickAndMortyApiClient>().
AddEndpointsApiExplorer().
AddSwaggerGen().
AddHttpClient("RickAndMortyPublicApi", config =>
{
    config.BaseAddress = new("https://rickandmortyapi.com/api/");
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var rickAndMortyApiClient = app.Services.GetService<RickAndMortyApiClient>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/rickyAndMorty/characters", () => rickAndMortyApiClient!.GetAllCharactersAvailable());

app.MapGet("/rickyAndMorty/characters/challengeFilter", () => rickAndMortyApiClient!.GetAllCharactersAvailableWithChallengeFilter());

app.Run();
